# Notas dia 11 de Agosto de 2023

## Requests

1. The communication starts
2. The client sends a request to the server
3. The server receives the request
4. The server must likely execute something
   _scripts,code,logic_
5. The server responds to the client
6. The communication ends

   ![Request](data:image/png;base64,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)

### Errores

- 100: Informational
- 200: Success
- 300: Redirection
- 400: Client Error
- 500: Server Error

### Estructura de redes

- Estrella
- Bus
- Anillo
- Malla
- Arbol
- Híbrida
- Punto a punto
- Punto a multipunto
- Multipunto a multipunto

### Requests JSON

- GET: Obtener datos
- POST: Crear datos
- PUT: Actualizar/Crear datos
- PATCH: Actualizar datos
- DELETE: Eliminar datos
- Idempotent: Si se repite la operación, el resultado es el mismo

| Method       | Request has Body? | Response has body? | Idempotent |
| ------------ | ----------------- | ------------------ | ---------- |
| POST         | YES               | YES                | NO         |
| GET          | NO\*              | YES                | YES        |
| Put          | YES               | NO                 | YES        |
| Patch/Update | YES               | YES                | NO         |
| Delete       | MAYBE             | MAYBE              | YES        |
