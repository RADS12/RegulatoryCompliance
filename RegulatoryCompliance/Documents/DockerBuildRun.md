# Building and Running RegulatoryCompliance with Docker

This guide explains how to build and run your .NET API using Docker.

---

## 1. Prerequisites
- Docker Desktop installed (Windows/Mac) or Docker Engine (Linux)
- Project contains a `Dockerfile` in the root directory

---

## 2. Build the Docker Image

Open a terminal in your project root and run:

```powershell
# Build the Docker image
# Replace 'regulatorycompliance:latest' with your preferred image name/tag

docker build -t regulatorycompliance:latest .
```

---

## 3. Run the Docker Container

```powershell
# Run the container, mapping port 8080 on your machine to port 80 in the container

docker run -p 8080:80 regulatorycompliance:latest
```

- Your API will be accessible at `http://localhost:8080`.

---

## 4. Additional Commands

- **List running containers:**
  ```powershell
  docker ps
  ```
- **Stop a container:**
  ```powershell
  docker stop <container-id>
  ```
- **Remove an image:**
  ```powershell
  docker rmi regulatorycompliance:latest
  ```

---

## 5. Next Steps
- Push your image to Docker Hub or Azure Container Registry for cloud deployment.
- Integrate Docker build/run steps in your CI/CD pipeline.

---

For more advanced scenarios (environment variables, volumes, multi-stage builds), let me know!
