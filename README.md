# Microservies architecture
This repo consists of sample api using the microservices architecture. One `srvcOne` api instance is run twice as two different services like in the `docker-compose.yml` to demonstrate microservices architecture.

### Docker setup

#### Run all containers
Once in this directory, building images using `docker-compose.yml` should be as straight as

`sudo docker build -t perfrunner .`

and running them as containers like

`docker compose up --no-build`


#### Run one container
Once this repo is cloned, perform the below steps to bring the service(s) up.

```
// Build image(s)
docker build -t srvcOne .

// Show images
docker images

// Run container for the image
docker run -it --rm -p 3000:8080 --name srvcOneCont srvcOne

// Show containers
docker ps
```
