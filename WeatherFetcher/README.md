Konzolová aplikace, která periodicky získává data o počasí z API ve formátu XML a převádí je do JSON, následně ukládá časové razítko i JSON do SQLite databáze.

Konfigurace aplikace je v souboru `appsettings.json`:
```json
{
  "DbPath": "WeatherDB.db",
  "ApiUrl": "https://pastebin.com/raw/PMQueqDV",
  "FetchIntervalSeconds": "3600"
}
```
Soubor `appsettings.json` musí být ve stejném adresáři jako spustitelná aplikace.

