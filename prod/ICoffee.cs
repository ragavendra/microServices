namespace prod
{
    public enum Ingredient {
        Cream,
        Milk,
        FrenchVanilla,
        Sugar,
        Coffee
    }

    public interface ICoffee
    {
        public double GetCost();

        public List<Ingredient> GetIngredients();
    }

    public class Coffee : ICoffee {

        public double GetCost() {
            return 1.1;
        }

        public List<Ingredient> GetIngredients() {
            return new List<Ingredient>() { Ingredient.Coffee };
        }
    }

    public abstract class CoffeeDecorator : ICoffee {

        protected ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee) {
            _coffee = coffee;
        }

        public virtual double GetCost() {
            return _coffee.GetCost();
        }

        public virtual List<Ingredient> GetIngredients() {
            return _coffee.GetIngredients();
        }
    }

    public class CreamDecorator : CoffeeDecorator {
        // private ICoffee _coffee;

        public CreamDecorator(ICoffee coffee) : base(coffee)
        {
        }

        /*
                public CreamDecorator(ICoffee coffee) {
                    _coffee = coffee;
                }*/

        public override double GetCost() {
            return _coffee.GetCost() + 0.20;
        }

        public override List<Ingredient> GetIngredients() {
            _coffee.GetIngredients().Add(Ingredient.Cream);
            return _coffee.GetIngredients();
        }
    }

    public class FrenchVanillaDecorator : CoffeeDecorator {
        // private ICoffee _coffee;

        public FrenchVanillaDecorator(ICoffee coffee) : base(coffee)
        {
        }

        /*
                public CreamDecorator(ICoffee coffee) {
                    _coffee = coffee;
                }*/

        public override double GetCost() {
            return _coffee.GetCost() + 0.25;
        }

        public override List<Ingredient> GetIngredients() {
            _coffee.GetIngredients().Add(Ingredient.FrenchVanilla);
            return _coffee.GetIngredients();
        }
    }
}
