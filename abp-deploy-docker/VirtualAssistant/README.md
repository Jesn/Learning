
# Rich Docker 部署操作步骤

## 配置修改

1. `appsetting.json` 或者 `appsettings.Production.json` 修改 数据库配置，redis配置
2. `https://auth.sample.com`、`https://vt.sample.com` 改成对应的域名
3. `/docker/nginx/cert`生成自己的域名证书进行替换
4. `/docker/nginx/conf.d/rich.conf`里面的域名配置和证书名称改成自己的
5. `docker-compose.yml`里面的域名配置改成自己的


## 运行docker-compose

```
docker-compose -f ./docker-compose.yml -f ./docker-compose.production.yml up -d
```