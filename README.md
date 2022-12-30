# Worker Service Clean Architecture

This is a `WorkerService` template project which has the flavour of clean architecture with message broker. This project template has most of the required tools to get started with long running services.

> PS: More improvements to come in the future ;)

What's included:

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Serilog](https://serilog.net/)
- [RabbitMQ](https://www.rabbitmq.com)
- [MassTransit](https://masstransit-project.com)
- [SendGrid](https://sendgrid.com/solutions/email-api/)

## Table of Content

- [Worker Service Clean Architecture](#worker-service-clean-architecture)
  - [Table of Content](#table-of-content)
  - [Quick Start](#quick-start)
    - [Prerequisites](#prerequisites)
    - [Development Environment Setup](#development-environment-setup)
    - [Run the RabbitMQ container](#run-the-rabbitmq-container)
    - [Build and run from source](#build-and-run-from-source)
  - [License](#license)

## Quick Start

After setting up your local DEV environment, you can clone this repository and run the solution.

### Prerequisites

You'll need the following tools:

- [.NET](https://dotnet.microsoft.com/download), version `>=7`
- [Visual Studio](https://visualstudio.microsoft.com/), version `>=2022` or [JetBrains Rider](https://jetbrains.com/rider/), version `>=2022`
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

### Development Environment Setup

First clone this repository locally.

- Install all of the the prerequisite tools mentioned above.

### Run the RabbitMQ container

Run below command to start your `RabbitMQ` container, which will acts as the message broker of the solution.

```bash
docker run -d --hostname rabbit-server --name rabbit -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=1qaz2wsx@W rabbitmq:3-management
```

### Build and run from source

With Visual studio:
Open up the solutions using Visual studio.

- Restore solution `nuget` packages.
- Rebuild solution once.
- Run the solution.

## License

Licensed under the [MIT](LICENSE) license.
