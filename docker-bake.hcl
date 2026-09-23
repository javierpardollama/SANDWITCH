group "default" {
  targets = [
    "sandwitch-service"  
  ]
}

target "sandwitch-service" {
  context    = "."
  dockerfile = "Sandwitch.Service/Sandwitch.Service/Dockerfile"
  tags       = ["sandwitch-service:latest"]
}
