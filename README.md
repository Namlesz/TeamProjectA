# TeamProjectA
Projekt zespołowy na przedmioty "Aplikacyjny projekt zespołowy" i "Zarządzanie jakością oprogramowania" na 1. roku studiów magisterskich.

Członkowie zespołu:
- Adam Sporczyk
- Adam Wiśniewski

### Aplikacja dla trenerów i ich podopiecznych

Spis treści:

- [1. Aplikacja](#1-aplikacja)
  - [1.1. Cel projektu](#11-cel-projektu)
  - [1.2. Opis projektu](#12-opis-projektu)
  - [1.3. Architektura aplikacji](#13-architektura-aplikacji)
  - [1.4. Opis funkcjonalności](#14-opis-funkcjonalności)
- [2. Technologia](#2-technologia)
  - [2.1. Frontend](#21-frontend)
    - [2.1.1. Użyte technologie](#211-użyte-technologie)
  - [2.2. Backend](#22-backend)
- [3. Uruchomienie aplikacji](#3-uruchomienie-aplikacji)
  - [3.1. Uruchomienie do testów za pomocą Dockera](#31-uruchomienie-do-testów-za-pomocą-dockera)
    - [3.1.1. Instrukcja użycia Dockera](#311-instrukcja-użycia-dockera)
    - [3.1.2. Przykład użycia Dockera](#312-przykład-użycia-dockera)
  - [3.2. Uruchomienie lokalnie frontendu](#32-uruchomienie-lokalnie-frontendu)
    - [3.2.1. Instalacja pakietów](#321-instalacja-pakietów)
    - [3.2.2. Uruchomienie wersji deweloperskiej](#322-uruchomienie-wersji-deweloperskiej)
    - [3.2.3. Uruchomienie wersji produkcyjnej](#323-uruchomienie-wersji-produkcyjnej)
  - [3.3. Uruchomienie lokalnie backendu](#33-uruchomienie-lokalnie-backendu)
- [4. Testy](#4-testy)
  - [4.1. Testy po stronie Frontendu](#41-testy-po-stronie-frontendu)
    - [4.1.1. Testy jednostkowe](#411-testy-jednostkowe)
    - [4.1.2. Testy E2E](#412-testy-e2e)
  - [4.2. Testy po stronie Backendu](#42-testy-po-stronie-backendu)

## 1. Aplikacja
### 1.1. Cel projektu
Utworzona aplikacja ma umożliwić trenerom i ich podopiecznym nawiązywanie znajomości, 
dzięki którym trenerzy będą mieli możliwość ustalania planów treningowych swoim podopiecznym.

### 1.2. Opis projektu
Aplikacja webowa została utworzona we frameworku Vue.js w wesji 3 z wykorzystaniem języka TypeScript.
Aplikacja komunikuje się poprzez zapytania HTTP z serwerem backendowym napisanym w technologii .NET.
Obie aplikacje hostowane są na platformie Microsoft Azure ([link do aplikacji webowej](https://project-a-team.azurewebsites.net/)).
Link do dokumentacji swagger: [link](https://project-a-team.azurewebsites.net/swagger/index.html)

### 1.3. Architektura aplikacji
Aplikacja została utworzona w architekturze klient-serwer. Klientem jest aplikacja webowa, która komunikuje się z serwerem poprzez zapytania HTTP.
Serwer został utworzony w architekturze REST API, a komunikacja z bazą danych odbywa się poprzez Entity Framework Core.
Struktura projektu została zaprojektowana w architekturze onion, w której wyróżniamy następujące warstwy:
- **Domain** - warstwa zawierająca modele, interfejsy
- **Application** - warstwa zawierająca logikę biznesową
- **Infrastructure** - warstwa zawierająca implementacje interfejsów repozytorium z warstwy Domain
- **Api** - warstwa zawierająca kontrolery, które są punktem wejścia do aplikacji
- **Web** - warstwa zawierająca aplikację webową
- **Tests** - warstwa zawierająca testy jednostkowe i integracyjne

### 1.4. Opis funkcjonalności
Po wejściu do aplikacji, użytkownik ma możliwość zalogowania się poprzez podanie swojej nazwy użytkownika.
Po zalogowaniu i przejściu na stronę główną, użytkownik może zobaczyć swoje obecne plany treningowe, o ile zostały utworzone.
Z poziomu bocznego paska nawigacji, użytkownik może przejść na ekrany: 
wyszukiwarki trenerów, listy zaproszeń oraz listy znajomych, oraz ma możliwość wylogowania się.
Po wejściu w widok trenerów, użytkownik ma możliwość wyszukania trenera po jego nazwie użytkownika,
w wyniku czego wyświetlone zostaną szczegóły trenera, który może zostać zaproszony do znajomych.
Na widoku listy zaproszeń, użytkownik może zobaczyć osoby, które zaprosiły go do znajomych,
a następnie zaakceptować lub odrzucić zaproszenie.
Na widoku listy znajomych, użytkownik może zobaczyć osoby, które już są znajomymi użytkownika.
Po kliknięciu w pozycję na liście, użytkownik przeniesiony zostanie do widoku szczegółów użytkownika.
W tym miejscu możliwe jest ustawienie i modyfikacja planów treningowych danej osoby.

*Bardziej szczegółową instrukcję użytkownika można zobaczyć [tutaj](https://docs.google.com/document/d/1Iis6_d4Nlcv8Q9pvOnz0xDNsSNmtpcVpPugmqhQzopc/edit?usp=sharing).*

## 2. Technologia

### 2.1. Frontend

#### 2.1.1. Użyte technologie:

- [Vue.js](https://vuejs.org)
- [Vite](https://vitejs.dev)
- [Pinia](https://pinia.vuejs.org)
- [Vue router](https://router.vuejs.org)
- [Vuetify](https://vuetifyjs.com/en/)
- [Vue I18n](https://vue-i18n.intlify.dev)
- [Vue query](https://tanstack.com/query/v4)
- [VueUse](https://vueuse.org)
- [VeeValidate](https://vee-validate.logaretm.com/v4/)
- [Cypress](https://www.cypress.io)
- [Vitest](https://vitest.dev)
- [Eslint](https://eslint.org)
- [Prettier](https://prettier.io)

## 2.2. Backend

#### 2.2.1. Użyte technologie:

- [ASP.NET](https://dotnet.microsoft.com/apps/aspnet)
- [MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver)
- [Mapster](https://www.nuget.org/packages/Mapster)
- [MediatR](https://www.nuget.org/packages/MediatR)
- [Moq](https://www.nuget.org/packages/Moq)
- [NBomber](https://www.nuget.org/packages/NBomber)
- [NUnit](https://www.nuget.org/packages/NUnit)
- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore)

## 3. Uruchomienie aplikacji

### 3.1. Uruchomienie do testów za pomocą Dockera

#### 3.1.1. Instrukcja użycia Dockera

- build
`docker build [ścieżka do pliku dockerfile] -t [nazwa obrazu]:[tag]`

- run image
`docker run -p [port hosta]:[port kontenera] [nazwa obrazu]:[tag]`

#### 3.1.2. Przykład użycia Dockera

Przykład użycia:

Ustaw terminal w katalogu głównym projektu. Następnie uruchom polecenie:

`docker build . -t teamprojecta:latest`

Po zbudowaniu obrazu uruchom go za pomocą następującego polecenia:

`docker run -p 8000:80 teamprojecta:latest -e ASPNETCORE_ENVIRONMENT='Production' ConnectionStrings:TeamProjectAppDb='[CONNECTION_STRING]`

Gdzie `[CONNECTION_STRING]` to ciąg połączenia do bazy danych.

Jeśli nie chcesz budować obrazu i uruchamiać kontenera, możesz użyć pliku docker-compose, aby zbudować i uruchomić
obraz. Uprzednio należy zmienić `[CONNECTION_STRING]` do bazy danych w pliku docker-compose.yml.
Aby to zrobić, uruchom następujące polecenie w katalogu głównym projektu:

`docker compose up`

*Ten przykład uruchomi aplikację na adresie http://localhost:8000*.

### 3.2. Uruchomienie lokalnie frontendu
#### 3.2.1. Instalacja pakietów
Należy otworzyć folder `src/TeamProjectA.Web` zawierający projekt frontendowy.

Następnie, należy zainstalować pakiety za pomocą polecenia:

`npm install`

Po prawidłowym zainstalowaniu pakietów, można uruchomić aplikację. Aby uruchomić wersję deweloperską,
należy wykonać polecenie

#### 3.2.2. Uruchomienie wersji deweloperskiej

`npm run dev`

*Aplikacja zostanie uruchomiona na adresie http://127.0.0.1:5173/*.

#### 3.2.3. Uruchomienie wersji produkcyjnej
Aby uruchomić produkcyjną wersję aplikacji, należy najpierw zbudować aplikację. 
W tym celu należy użyć polecenia:

`npm run build`

Po poprawnym zbudowaniu aplikacji utworzony zostanie folder `build` zawierający zbudowaną aplikację.

Aby uruchomić zbudowaną aplikację można na przykład użyć polecenia:

`serve -s build`

*Aplikacja zostanie uruchomiona na adresie http://localhost:3000*.

**Aby aplikacja działała poprawnie należy również uruchomić Backend.** 

### 3.3. Uruchomienie lokalnie backendu

Aby uruchomić backend naley ustawić się w folderze `src/TeamProjectA.Api` i wykonać polecenie:

`dotnet build`

A następnie:

`dotnet run`

Alternatywnie możemy uruchomić aplikację poprzez dockera link -> [3.1.1. Instrukcja użycia Dockera](#311-instrukcja-użycia-dockera)

## 4. Testy

### 4.1. Testy po stronie Frontendu
#### 4.1.1. Testy jednostkowe
Testy jednostkowe obsługiwane są poprzez framework Vitest. Aby uruchomić testy należy użyć polecenia:

`vitest`

lub, jeśli chcemy uruchomić testy w trybie z widokiem UI:

`vitest --ui`

lub uruchomić testy poprzez IDE.

*Więcej informacji na temat testów jednostkowych można zobaczyć [tutaj](https://docs.google.com/document/d/161wIlvncjs8s8SH3qJOzpQLuskzMM12Pj3N9FCaC7w0/edit?usp=sharing)*.

#### 4.1.2. Testy E2E
Testy E2E w aplikacji obsługiwane są przez framework Cypress. Aby uruchomić aplikację Cypress, należy wywołać polecenie:

`cypress open`

W aplikacji możemy uruchamiać testy, podglądać ich przebieg działania oraz wyniki.

Alternatywnie, testy można uruchomić w konsoli za pomocą polecenia

`cypress run`

*Więcej informacji na temat testów E2E można zobaczyć [tutaj](https://docs.google.com/document/d/1Jd_ImszGPKUfrRuKLSVFaWSSOAZmFC9mzr-D9Z_X16Y/edit?usp=sharing)*.


### 4.2. Testy po stronie Backendu
Testy wykorzystują bibliotekę NUnit, aby uruchomć testy należy wykonać komendę:
`dotnet test`

*Więcej informacji na temat testów jednostkowych można zobaczyć [tutaj](https://docs.google.com/document/d/161wIlvncjs8s8SH3qJOzpQLuskzMM12Pj3N9FCaC7w0/edit?usp=sharing)*.


