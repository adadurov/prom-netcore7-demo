
# What it is and is not

This is a demo of ASP.NET Core + Prometheus + Grafana dashboard
for host and app metrics collected using prometheus-net.AspNetCore nuget package.
It runs within docker-compose containers.

## What it is not (but could be after next steps)

This demo doesn't include product/business metrics (yet).

# How to build and use

## Build and launch the containers (podman- or docker- compose)

`docker build -t prom-demo-api`

`docker compose up`

### URLs of services from the outside of docker-compose network:

- Swagger for WeatherForecast is at http://localhost:80
- Prometheus is at http://localhost:9090)
- Grafana is at http://localhost:3000

## Connect Grafana to Prometheus and configure a dashboard

### Add data source to Grafana:
- select cog (bottom left side menu) for settings
- choose Data Sources
- click Add new data source (blue button to the right)
- choose Prometheus
- URL: http://prometheus:9090 (thg host is inside docker-compose network)
- click 'test and save' at the bottom

### Import a preconfigured dashboard JSON file
- choose 'Dashboards' > import > upload dashboard JSON file
- choose an existing dashboard from grafana folder in the repository (prometheus-net_rev4.json)
- run like curl (in bash infinite loop, maybe 20..30 in parallel)

## Run some workload against Weather Forecast API

`while true; do curl -X 'GET' 'http://localhost/WeatherForecast' > /dev/null; sleep 1; done`

Add '&' to send the process to background and repeat a few times to run ~7..10 RPS.

## Observe the metrics on your dashboard

## Some links to how-tos

- collecting business metrics: 
https://learn.microsoft.com/en-us/dotnet/core/diagnostics/metrics-collection
- collecting app and host metrics (API responsiveness, resource consumption etc.):
https://aevitas.medium.com/expose-asp-net-core-metrics-with-prometheus-15e3356415f4
- yet another ASP.NET core metrics collection how-to:
https://dale-bingham-soteriasoftware.medium.com/net-core-web-api-metrics-with-prometheus-and-grafana-fe84a52d9843


## Prometheus-related links

- https://prometheus.io/docs/prometheus/latest/getting_started/
- https://github.com/prometheus-net/prometheus-net/
