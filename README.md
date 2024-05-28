# Tesla

This repository is for implementing some functionalities related to Tesla.
Updates will be made based on mood.

## doc

1. [overview](./doc/01.architecture.md)
2. [vehicle state](./doc/02.vehicle-state.md)
3. [websocket](./doc/03.streaming.md)

## dev

1. redirect to tesla, and login

    ![1](./doc/images/dev/index.png)
    ![2](./doc/images/dev/login.png)

2. copy the code

    ![1](./doc/images/dev/code.png)

3. copy the verifier code

    ![1](./doc/images/dev/verifier.png)

4. call token endpoint with code and verifier

    ![1](./doc/images/dev/token.png)

## run

- docker

    ```ps
    docker build -f src/Web/TeslaApi.Web/Dockerfile .
    ```

- docker compose

    ```ps
    docker-compose -f ./docker-compose.debug.yml up
    ```
- aspire demo

    ```ps
    dotnet run --project ./src/Tesla.AppHost/
    ```

## reference

- [timdorr](https://tesla-api.timdorr.com/)
- [teslamate](https://docs.teslamate.org/)
- [garnet](https://microsoft.github.io/garnet/docs)
