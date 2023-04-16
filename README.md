# TeamProjectA
Table of context:
- [Docker PL](#Docker-PL)
  - [Instrukcja użycia Dockera](#instrukcja-użycia-dockera)
  - [Przykład użycia Dockera](#przykład-użycia-dockera)
  
- [Docker EN](#docker-en)
  - [Docker usage instruction](#docker-usage-instruction)
  - [Docker usage example](#docker-usage-example)

# Docker PL

## Instrukcja użycia Dockera

- build `docker build [ścieżka do pliku dockerfile] -t [nazwa obrazu]:[tag]`
- run image`docker run -p [port hosta]:[port kontenera] [nazwa obrazu]:[tag]`

## Przykład użycia Dockera

Przykład użycia:

Ustaw terminal w katalogu głównym projektu. Następnie uruchom polecenie:

`docker build . -t teamprojecta:latest`

Po zbudowaniu obrazu uruchom go za pomocą następującego polecenia:

`docker run -p 8000:80 teamprojecta:latest`.

Jeśli nie chcesz budować obrazu i uruchamiać kontenera, możesz użyć pliku docker-compose, aby zbudować i uruchomić obraz. Aby to zrobić, uruchom następujące polecenie w katalogu głównym projektu:

`docker compose up`.

*Ten przykład uruchomi aplikację na adresie http://localhost:8000*.

# Docker EN

## Docker usage instruction

- build `docker build [path to dockerfile] -t [name of image]:[tag]`
- run image`docker run -p [host port]:[container port] [name of image]:[tag]`

## Docker usage example

Example usage:

Set up the terminal in the root directory of the project. Next run a command:

`docker build . -t teamprojecta:latest`

After the image is built, run the image with the following command:

`docker run -p 8000:80 teamprojecta:latest`

If you don't want to build the image and run the container, you can use the docker-compose file to build and run the image. To do
this, run the following command in project root directory:

- use docker-compose `docker compose up`

*This example will run the app on address http://localhost:8000*
