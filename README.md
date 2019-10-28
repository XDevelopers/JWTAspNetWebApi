JSON Web Tokens (JWT) in ASP.NET Web Api
===============

Tutorial shows how to Issue JSON Web Token in ASP.NET Web API 2 and Owin middleware, then build list of Resource Servers relies on the Token Issuer Party (Authorization Server)


Passo para testar

Colocar pra rodar primeiro AuthorizationServer.Api

Criar um POST para `/OAuth2/Token`


```

curl -X POST \
  http://localhost:18292/oauth2/token \
  -H 'Accept: */*' \
  -H 'Accept-Encoding: gzip, deflate' \
  -H 'Cache-Control: no-cache' \
  -H 'Connection: keep-alive' \
  -H 'Content-Length: 108' \
  -H 'Content-Type: application/x-www-form-urlencoded' \
  -H 'Host: localhost:18292' \
  -d 'username=SysSuperAdmin&password=SysSuperAdmin&grant_type=password&client_id=099153c2625149bc8ecb3e85e03f0022'
```

Copiar o **access_token** do Resultado do POST efetuado acima:

```
{
    "access_token": "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1bmlxdWVfbmFtZSI6IlN5c1N1cGVyQWRtaW4iLCJzdWIiOiJTeXNTdXBlckFkbWluIiwicm9sZSI6WyJNYW5hZ2VyIiwiU3VwZXJ2aXNvciJdLCJpc3MiOiJodHRwOi8vand0YXV0aHpzcnYuYXp1cmV3ZWJzaXRlcy5uZXQiLCJhdWQiOiIwOTkxNTNjMjYyNTE0OWJjOGVjYjNlODVlMDNmMDAyMiIsImV4cCI6MTU3MjI3MTg1MywibmJmIjoxNTcyMjcwMDUzfQ.Xj84nWhxG9b0iGZEk5eclFU5MZvzpFK0QhWbFUNigjs",
    "token_type": "bearer",
    "expires_in": 1799
}
```

Colocar pra rodar o ResourceServer.Api

Criar um POST para testar o acesso com o Token Recem Gerado, seguindo o exemplo abaixo:

Endpoint para validar o conteúdo do Payload

```
curl -X GET \
  http://localhost:18303/api/data/authorized \
  -H 'Accept: */*' \
  -H 'Accept-Encoding: gzip, deflate' \
  -H 'Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1bmlxdWVfbmFtZSI6IlN5c1N1cGVyQWRtaW4iLCJzdWIiOiJTeXNTdXBlckFkbWluIiwicm9sZSI6WyJNYW5hZ2VyIiwiU3VwZXJ2aXNvciJdLCJpc3MiOiJodHRwOi8vand0YXV0aHpzcnYuYXp1cmV3ZWJzaXRlcy5uZXQiLCJhdWQiOiIwOTkxNTNjMjYyNTE0OWJjOGVjYjNlODVlMDNmMDAyMiIsImV4cCI6MTU3MjI3MTg1MywibmJmIjoxNTcyMjcwMDUzfQ.Xj84nWhxG9b0iGZEk5eclFU5MZvzpFK0QhWbFUNigjs' \
  -H 'Connection: keep-alive' \
  -H 'Host: localhost:18303' \
  -H 'cache-control: no-cache'

```


Só Debugar e verificar os ponto necessários de alteração;