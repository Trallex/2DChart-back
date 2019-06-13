cd C:\C#\2DChart\2DChart-back\2DChart
heroku login
docker login
docker build . -t chart2dapi
heroku container:login
heroku container:push web -a chart2d-api
heroku container:release web -a chart2d-api
heroku logs --tail -a chart2d-api