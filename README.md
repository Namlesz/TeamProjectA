# TeamProjectA

# Docker instruction

- build `docker build [path to dockerfile] -t [name of image]:[tag]`
- run image`docker run -p [host port]:[container port] [name of image]:[tag]`

Example usage:

Set up the terminal in the root directory of the project. Next run a command:

`docker build . -t teamprojecta:latest`

After the image is built, run the image with the following command:

`docker run -p 8000:80 teamprojecta:latest`

If you don't want to build the image and run the container, you can use the docker-compose file to build and run the image. To do
this, run the following command in project root directory:

- use docker-compose `docker compose up`
