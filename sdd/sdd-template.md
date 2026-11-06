# Описание проектирования программного обеспечения (SDD — Software Design Description)

## 1. Введение
Настоящий документ SDD описывает системные требования, архитектурное устройство, структуру базы данных и спецификацию интерфейсов веб-приложения **«TourGuide»** на платформе **C# (.NET 8 / ASP.NET Core)**, спроектированные на основе спецификации требований SRS.

## 2. Архитектура системы (High-Level Architecture)
Система строится по трёхзвенной клиент-серверной архитектуре (Client-Server REST Architecture), упакованной в контейнеры **Docker**:

1. **Presentation Layer (Клиентский уровень — React SPA)**:
   - Отрисовка каталога достопримечательностей (`DashboardPage`) и детальной страницы места (`PlacePage`).
   - Взаимодействие с интерактивной картой через библиотеку `Leaflet` и тайлы `OpenStreetMap`.
   - Формирование пользовательского маршрута и отправка текстовых промптов в модуль АИ-рекомендаций.
2. **Application & Business Logic Layer (Серверный уровень — C# / ASP.NET Core Web API)**:
   - `AuthController` и `ASP.NET Core Identity`: регистрация, выпуск и валидация JWT-токенов (`REQ-SEC-001`).
   - `PlacesController` и `PlaceService`: фильтрация достопримечательностей по категориям, времени осмотра, рейтингу и географическому радиусу (`REQ-FUNC-001`, `REQ-FUNC-002`).
   - `RoutesController` и `RouteService`: сохранение пользовательских маршрутов экскурсий, расчёт километража и общего времени прохождения (`REQ-FUNC-003`, `REQ-FUNC-004`).
   - `FavoritesController`: управление избранными локациями пользователя (`REQ-FUNC-005`).
   - `AiRecommendationController` и `AiAgentService`: интеграция с внешним LLM API, сопоставление ответа с записями в БД PostgreSQL с учётом заданного километража и fallback-обработка ошибок (`REQ-FUNC-007`).
3. **Data Access Layer (Уровень хранения данных — Entity Framework Core + PostgreSQL)**:
   - Реляционная СУБД **PostgreSQL 16** для хранения пользователей, карточек мест, категорий, маршрутов и избранного.
   - Доступ к данным через ORM **Entity Framework Core** (Code-First миграции, асинхронные запросы `LINQ` с отслеживанием производительности $\le 2$ с по `REQ-PERF-001`).

## 3. Проектирование базы данных (Схема сущностей EF Core)
- **`User` (`AspNetUsers`)**: `Id (UUID)`, `Email`, `PasswordHash`, `FullName`, `CreatedAt`.
- **`Place` (Достопримечательность)**: `Id`, `Title`, `Description`, `HistoryInfo`, `Category` (`Музеи`, `Парки`, `Архитектура`, `Еда`), `Rating (decimal)`, `DurationMinutes (int)`, `WorkingHours`, `Latitude`, `Longitude`, `ImageUrl`.
- **`ExcursionRoute` (Маршрут экскурсии)**: `Id`, `UserId (FK)`, `Title`, `TotalDistanceKm`, `TotalDurationMinutes`, `CreatedAt`.
- **`RoutePoint` (Точка маршрута)**: `Id`, `RouteId (FK)`, `PlaceId (FK)`, `OrderIndex (int)`.
- **`FavoritePlace` (Избранное)**: `UserId (FK)`, `PlaceId (FK)`, `AddedAt`.

## 4. Спецификация системных интерфейсов (REST API Endpoints)

| HTTP-метод и маршрут | Описание | Связанное требование |
| :--- | :--- | :--- |
| `POST /api/auth/register` | Регистрация нового пользователя | REQ-SEC-001 |
| `POST /api/auth/login` | Авторизация и получение JWT-токена | REQ-SEC-001 |
| `GET /api/places` | Получение каталога мест с фильтрацией (`category`, `minRating`, `maxDuration`) | REQ-FUNC-001, REQ-FUNC-002 |
| `GET /api/places/{id}` | Получение детальной карточки достопримечательности | REQ-FUNC-001 |
| `POST /api/routes` | Сохранение пользовательского маршрута экскурсии (упорядоченный список `PlaceId`) | REQ-FUNC-003, REQ-FUNC-004 |
| `GET /api/routes/my` | Получение списка сохранённых маршрутов текущего пользователя | REQ-FUNC-005 |
| `POST /api/favorites/{placeId}` | Добавление/удаление достопримечательности в «Избранное» | REQ-FUNC-005 |
| `POST /api/ai/recommend` | Запрос к АИ-агенту (`prompt`, `maxDistanceKm`, `durationMinutes`) для подбора мест | REQ-FUNC-007 |