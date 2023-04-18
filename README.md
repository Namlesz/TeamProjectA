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

`docker run -p 8000:80 teamprojecta:latest -e ASPNETCORE_ENVIRONMENT='Production' ConnectionStrings:TeamProjectAppDb='[CONNECTION_STRING]`.

Gdzie `[CONNECTION_STRING]` to ciąg połączenia do bazy danych.

Jeśli nie chcesz budować obrazu i uruchamiać kontenera, możesz użyć pliku docker-compose, aby zbudować i uruchomić
obraz. Uprzednio należy zmienić `[CONNECTION_STRING]` do bazy danych w pliku docker-compose.yml.
Aby to zrobić, uruchom następujące polecenie w katalogu głównym projektu:

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

`docker run -p 8000:80 teamprojecta:latest -e ASPNETCORE_ENVIRONMENT='Production' ConnectionStrings:TeamProjectAppDb='[CONNECTION_STRING]`

Where `[CONNECTION_STRING]` is a connection string to the database.

If you don't want to build the image and run the container, you can use the docker-compose file to build and run the
image. Previously, you must change the `[CONNECTION_STRING]` to the database in the docker-compose.yml file.
To do this, run the following command in project root directory:

- use docker-compose `docker compose up`

*This example will run the app on address http://localhost:8000*
