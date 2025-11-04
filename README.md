# 📊 Marketing Insights

**Marketing Insights** is a web application designed to help businesses and marketers **analyze the performance of their marketing campaigns across multiple channels**.  
It centralizes marketing data, automatically calculates **key performance indicators (KPIs)**, and provides an **interactive analytics dashboard** for smarter decision-making.

---

## 🚀 Main Features

- 🔐 User authentication (Admin / Marketer roles)
- 🏢 Company and campaign management
- 📊 Track campaign metrics (impressions, clicks, conversions, spend, revenue)
- 📈 Automatic KPI calculation:
  - CTR (Click Through Rate)
  - CPA (Cost Per Acquisition)
  - ROI (Return On Investment)
- 📄 Export reports to **PDF** and **Excel**
- 📆 Filter by date range, marketing channel, and campaign type
- 📉 Interactive dashboard with visual analytics (charts, graphs)

---

## 🧱 Project Architecture

This project follows **Clean Architecture principles**:

```
📦 MarketingInsights
├── 📁 Domain           # Entities and business logic
├── 📁 Application      # Services and Use Cases (CQRS)
├── 📁 Infrastructure   # Database access, Repositories
├── 📁 API              # ASP.NET Core Web API (Controllers)
└── 📁 Frontend         # User Interface (MVC)
```

---

## ⚙️ Technologies Used

| Layer | Technologies |
|--------|---------------|
| **Backend** | ASP.NET Core 9 (Web API) |
| **Frontend** | ASP.NET MVC |
| **Database** | SQL Server (EF Core + LINQ) |
| **Authentication** | JWT + ASP.NET Identity |
| **Exports** | iTextSharp (PDF), EPPlus (Excel) |
| **Visualization** | Chart.js / Recharts |
| **Optional** | Docker, Azure App Service / Container Registry |

---

## 🧩 Data Model (Main Entities)

- **User** → Handles authentication and roles  
- **Company** → Represents a company or marketing account  
- **Channel** → Defines the marketing channel (Facebook, Google, Email, etc.)  
- **Campaign** → Marketing campaign details  
- **CampaignMetric** → Performance data (impressions, clicks, revenue, etc.)  
- **Report** → Exported report files (PDF/Excel)  
- **KpiSetting** → User preferences for KPI display  

---

## 🧠 KPI Examples

| Name | Formula | Description |
|------|----------|-------------|
| **CTR** | (Clicks / Impressions) × 100 | Click-Through Rate |
| **CPA** | Spend / Conversions | Cost per Acquisition |
| **ROI** | (Revenue – Spend) / Spend | Return on Investment |

---

## 📄 License
This project is licensed under the **MIT License** – free to use and modify.
