#!/bin/sh
if [ $# -eq 0 ]; then
  echo "Please provide a value of 'start' or 'create' as the first argument."
  exit 0
elif [ $1 == "create" ]; then
  docker-machine create redis-manager0
fi

docker-machine start redis-manager0
docker-machine ssh redis-manager0 -- "docker run -d -p 7000:6379 redis"
