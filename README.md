
# How to use


## Запускаем контейнеры (пока только 1)

docker build -t prom-demo-api . && docker run --rm -it -p 80:80 prom-demo-api


## Собираем бизнес-метрики

https://learn.microsoft.com/en-us/dotnet/core/diagnostics/metrics-collection


## Собираем метрики приложения (отзывчивость API, потребление ресурсов и т.д.)

https://aevitas.medium.com/expose-asp-net-core-metrics-with-prometheus-15e3356415f4


## Еще один сбор логов ASP.NET Core (все в docker)

https://dale-bingham-soteriasoftware.medium.com/net-core-web-api-metrics-with-prometheus-and-grafana-fe84a52d9843



## Полезные ссылки

https://prometheus.io/docs/prometheus/latest/getting_started/

https://github.com/prometheus-net/prometheus-net/



## Прочие ссылки

https://stackoverflow.com/questions/74554219/wiring-up-docker-compose-prometheus-with-bare-asp-net-core-web-api-using-https
