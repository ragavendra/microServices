using Confluent.Kafka;
using prod;

var config = new ProducerConfig { BootstrapServers = "kafka:29092" };

Action<DeliveryReport<Null, string>> handler_2 = handler_ =>
  Console.WriteLine(handler_.Error.IsError ? "Delivery error - " + handler_.Error.Reason : "Message delivered to - " + handler_.TopicPartitionOffset);

ICoffee coffee = new Coffee();

// add cream
CreamDecorator creamDecorator = new CreamDecorator(coffee);
if (creamDecorator.GetCost() == 1.3)
  Console.WriteLine("After adding cream, total is " + creamDecorator.GetCost().ToString());

using (var p = new ProducerBuilder<Null, string>(config).Build())
{

  try
  {
    // p.Flush();

    for (int i = 0; i < 100; i++)
    {
      //var msg = new Message<int, string> { Value = "Some text here" };
      p.Produce("sample-topic", new Message<Null, string> { Value = "Sending this msg # " + i.ToString() }, handler_2);
    }

    // wait for up to 10 seconds for any inflight messages to be delivered.
    p.Flush(TimeSpan.FromSeconds(10));

    // var newMsg = await p.ProduceAsync("sample-topic", new Message<Null, string> { Value = "Message single" });
    // Console.WriteLine($"Delivered '{newMsg.Value}' to '{newMsg.TopicPartitionOffset}'");
  }
  catch (ProduceException<Null, string> ex)
  {
    Console.WriteLine("Deliver failed - " + ex.Error.Reason);
  }
}

