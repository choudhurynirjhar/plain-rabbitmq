# Plain Rabbitmq

Plain Rabbitmq is a plain and simple wrapper around RabbitMQ.Client encapsulating the boilerplate code.

## Installation

Use the Nuget package manager [Nuget](https://www.nuget.org/packages/Plain.RabbitMQ/) to install Plain.RabbitMQ

```bash
Install-Package Plain.RabbitMQ -Version 0.0.0.3
```

## Usage

DI Registration

```csharp
services.AddSingleton<IConnectionProvider>(new ConnectionProvider("Queue Url"));
services.AddSingleton<ISubscriber>(x => new Subscriber(x.GetService<IConnectionProvider>(),
	"exchange name",
    "queue name",
    "routing key",
    ExchangeType.Topic));
services.AddScoped<IPublisher>(x => new Publisher(x.GetService<IConnectionProvider>(),
	"exchange name",
    ExchangeType.Topic));
```

Publisher

```csharp
publisher.Publish(JsonConvert.SerializeObject(object), "routing key", headers);
```

Subscriber
```csharp
subscriber.Subscribe((message, header) => {
	Console.WriteLine(message);
    return true;
});
```

Example video available in YouTube here: https://youtu.be/rUKqaO8IQCE

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)