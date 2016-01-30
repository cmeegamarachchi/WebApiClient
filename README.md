# Simple .net WebAPI client

Usage

```cs
var apiClient = new WebApiRequest<YourType>("your-api-endpoint");
var results = await apiClient.GetDataAsync();
```

To build

- Restore packages
- Build