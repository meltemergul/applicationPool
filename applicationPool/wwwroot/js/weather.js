function fetchWeatherData(city) {
    $.ajax({
        url: `https://api.weatherapi.com/v1/current.json?key=96140583fbe1e693ef155b47c8714d74&q=${city}&lang=tr`,
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            displayWeatherData(data);
        },
        error: function (error) {
            console.error("API çağrısında hata:", error);
        }
    });
}
function displayWeatherData(data) {
    var weatherHtml = `
        <div>
            <h2>${data.location.name}</h2>
            <p>Gündoğumu: ${new Date(data.location.localtime).toLocaleTimeString()}</p>
            <p>Durum: ${data.current.condition.text}</p>
            <p>Sıcaklık: ${data.current.temp_c}°C</p>
            <img src="https:${data.current.condition.icon}" alt="${data.current.condition.text}">
        </div>
    `;
    $('#weather-info').html(weatherHtml);
}
