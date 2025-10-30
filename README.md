# 🔗 URL Shortener – React + C# .NET 8

A simple full-stack **URL Shortener** built using **React (via CDN)** for the frontend and **C# .NET Web API** for the backend.  
It allows users to shorten long URLs and redirect from short links to the original ones.

---

## 🧩 Project Structure
```
url-shortener/
│
├── backend/
│ ├── UrlShortener.csproj
│ ├── Program.cs
│ ├── Controllers/
│ │ └── UrlController.cs
│ ├── Models/
│ │ └── UrlModel.cs
│ ├── Services/
│ │ └── UrlService.cs
│ └── Properties/
│ └── launchSettings.json
│
└── frontend/
├── index.html
├── app.js
```

---

## ⚙️ Tech Stack

**Frontend:**  
- React (CDN via unpkg)  
- TailwindCSS (CDN)  
- JavaScript Fetch API  

**Backend:**  
- .NET 8 Web API (C#)  
- ASP.NET Core MVC  
- In-memory storage (no database)  
- Swagger (for API testing)

---

## 🚀 Features

- Shorten long URLs into short links  
- Redirect short URLs to original pages  
- Clean, minimal Tailwind UI  
- Modular backend (Controllers, Services, Models)  
- Cross-Origin (CORS) enabled for frontend communication  

---

## 🛠️ Setup Instructions

### 🧱 Backend Setup
```bash
cd backend
dotnet restore
dotnet run

💻 Frontend Setup

No build tools needed — just open the file directly:
cd frontend

🔌 API Endpoints
Method	Endpoint	Description
POST	/api/url/shorten	Shortens a long URL
GET	/api/url/{id}	Redirects to original URL

🧠 Code Highlights

Backend:

UrlService.cs → Handles short URL generation & in-memory storage

UrlController.cs → Exposes API endpoints

Program.cs → Registers services, enables CORS, maps routes

Frontend:

app.js → React component using fetch() to call API

index.html → Includes React, Tailwind, and mounts app
