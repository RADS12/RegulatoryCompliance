# API Gateway Integration Guide (Azure API Management)

This guide explains how to integrate your .NET API with an API Gateway, specifically Azure API Management (APIM).

---

## 1. Prerequisites
- Your API exposes a Swagger/OpenAPI document (already enabled with Swashbuckle).
- You have access to Azure and can create/manage APIM resources.

---

## 2. Steps to Integrate with Azure API Management

### Step 1: Create or Use an APIM Instance
- In Azure Portal, search for "API Management" and create a new instance or use an existing one.

### Step 2: Import Your API
- In APIM, go to "APIs" > "+ Add API" > "OpenAPI".
- Provide your Swagger/OpenAPI URL (e.g., `https://yourapp.azurewebsites.net/swagger/v1/swagger.json`) or upload the file.
- Complete the import wizard.

### Step 3: Configure Policies
- In the APIM designer, you can:
  - Add authentication (JWT, OAuth2, subscription keys)
  - Set rate limiting and quotas
  - Enable caching
  - Transform requests/responses (e.g., add/remove headers)
  - Add logging and monitoring

### Step 4: Secure Your API
- Require subscription keys or OAuth/JWT for access.
- Optionally, restrict IP ranges or add custom headers.

### Step 5: Update Clients
- Change your client applications to use the APIM endpoint (e.g., `https://<apim-name>.azure-api.net/<api-path>`) instead of the direct API URL.
- Pass required headers (e.g., subscription key) if configured.

### Step 6: Monitor and Manage
- Use APIM analytics for usage, errors, and performance.
- Update policies as needed for security, scaling, or transformation.

---

## 3. Optional Backend Changes
- If you use subscription keys or custom headers, update your API to read those values from request headers.
- For advanced scenarios, handle forwarded headers (e.g., `X-Forwarded-For`) for client IP tracking.

---

## 4. Example: Protecting with Subscription Key
- In APIM, require a subscription key for your API.
- In your .NET API, read the key from `Request.Headers["Ocp-Apim-Subscription-Key"]` if you want to validate it manually.

---

## 5. References
- [Azure API Management Documentation](https://learn.microsoft.com/en-us/azure/api-management/)
- [Import and Publish APIs](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish)
- [APIM Policies](https://learn.microsoft.com/en-us/azure/api-management/api-management-policies)

---

If you need a sample APIM policy, custom header handling, or automation script, let me know!
