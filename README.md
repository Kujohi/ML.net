# Movie Recommendation API

This is a .NET-based web API for predicting movie ratings using a machine learning model built with ML.NET.

## Features
- **Predict Movie Ratings**: Given a `userId` and `movieId`, the API predicts the rating.
- **ML.NET Integration**: Utilizes a trained ML.NET model for recommendations.
- **RESTful API**: Easily integrate with frontend applications or other services.

## Requirements
- .NET 6 or later
- ML.NET 1.8.0
- Postman or any API testing tool (optional)

## Setup Instructions

### 1. Clone the Repository
```bash
git clone <repository-url>
cd WebApplication
```

### 2. Install Dependencies
```bash
dotnet add package Microsoft.ML

dotnet add package Microsoft.ML.Recommender

dotnet add package Microsoft.Extensions.ML
```

### 3. Build and Run the API
```bash
dotnet build
dotnet run
```

The API will start and listen on `http://localhost:5014`.

### 4. Test the API
Use Postman or `curl` to send a GET request:

```bash
curl -X GET "http://localhost:5014/api/recommendation" \
     -H "Content-Type: application/json" \
     -d '{"userId": 1, "movieId": 101}'
```

### 5. API Endpoints

- **GET /api/recommendation**
  - **Request Body**:
    ```json
    {
        "userId": 1,
        "movieId": 101
    }
    ```
  - **Response**:
    ```json
    {
        "rating": 4.5
    }
    ```

## Error Handling
- **400 Bad Request**: Missing or invalid input data.
- **500 Internal Server Error**: Model loading issues or internal exceptions.

## Troubleshooting
- Ensure all required NuGet packages are installed.
- If encountering `FileNotFoundException` for `Microsoft.ML.Recommender`, ensure it's properly referenced in the `.csproj` file.
- If the API throws a `BadHttpRequestException`, ensure that you're providing a proper JSON body in POST requests.

## Contributing
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes.
4. Push to your fork and submit a pull request.

## License
This project is licensed under the MIT License.

