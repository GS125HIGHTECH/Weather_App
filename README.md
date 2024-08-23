<h1>Weather App</h1>

<p align="left">
  <img src="https://github.com/user-attachments/assets/687eafbb-c874-4080-8710-75c97c07b7fd" alt="Weather App Screenshot" width="600">
</p>

<h2>Overview</h2>

<p><strong>Weather App</strong> is an ASP.NET Core web application that allows users to check the weather forecast for a given day and location. This project demonstrates how to integrate weather data into a web application using ASP.NET Core and modern web development practices.</p>

<h2>Features</h2>

<ul>
  <li>Check current weather conditions for any location.</li>
  <li>View weather forecasts for the upcoming days.</li>
  <li>User-friendly interface with responsive design.</li>
  <li>Integration with external weather APIs for real-time data.</li>
  <li>Integration with external Google Maps APIs for searching addresses.</li>
</ul>

<h2>Getting Started</h2>

<p>To get a local copy of the Weather App up and running, follow these simple steps.</p>

<h3>Prerequisites</h3>

<ul>
  <li><a href="https://dotnet.microsoft.com/download/dotnet/6.0">.NET 6 SDK</a> or later</li>
  <li><a href="https://visualstudio.microsoft.com/">Visual Studio</a></li>
  <li>An API key from a weather service provider (<a href="https://www.weatherapi.com/">WeatherAPI.com</a>).</li>
</ul>

<h3>Installation</h3>

<ol>
  <li><strong>Clone the Repository</strong></li>

  <pre><code>git clone https://github.com/GS125HIGHTECH/Weather_App.git</code></pre>

  <li><strong>Configure the Weather API</strong>
    <ul>
      <li>Register for an API key from a weather data provider (<a href="https://www.weatherapi.com/">WeatherAPI.com</a>).</li>
      <li>Open <code>appsettings.json</code> and add your API key:</li>
    </ul>
  </li>

  <pre><code>
  "ExternalApis": {
    "RapidAPI": {
      "Key": "YOUR_API_KEY_HERE",
      "Url": "https://weatherapi-com.p.rapidapi.com/",
      "Address": "weatherapi-com.p.rapidapi.com",
      "EndPoints": {
        "WeatherCurrent": "current.json",
        "WeatherForecast": "forecast.json"
      }
    }
  }
  </code></pre>

  <li><strong>Run the Application</strong></li>

</ol>

<h2>Usage</h2>

<ol>
  <li>Open the application in your web browser.</li>
  <li>Enter a location (city or country name).</li>
  <li>Click the "Check Weather" button to view the forecast.</li>
</ol>

<h2>License</h2>

<p>This project is licensed under the MIT License - see the <a href="LICENSE">LICENSE</a> file for details.</p>
