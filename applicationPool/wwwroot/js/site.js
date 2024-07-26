$(document).ready(function () {
    const majorCities = ["London", "İstanbul", "Berlin", "Paris"];
    majorCities.forEach(city => {
        fetchWeatherForCity(city, '#majorCitiesWeather');
    });

    $('#searchBtn').click(function () {
        var cityName = $('#cityName').val();
        if (cityName) {
            fetchWeatherForCity(cityName, '#weatherInfo');
        } else {
            alert('Please enter a city name.');
        }
    });

    function fetchWeatherForCity(cityName, targetElement) {
        $.ajax({
            url: '/Weather/GetWeather',
            type: 'POST',
            data: { cityName: cityName },
            success: function (data) {
                var sunrise = new Date(data.sys.sunrise * 1000).toLocaleTimeString();
                var iconUrl = `http://openweathermap.org/img/w/${data.weather[0].icon}.png`;

                $(targetElement).append(`
                    <div class="col-sm-10 text-white rounded" style="background-color:	#4FC3F7; margin:3px " class="cityWeather">
                        <h2>${data.name}</h2>
                        <div class="row">
                        <div class="col">
                        <img src="${iconUrl}" alt="Weather icon" width="100px" height="100px">
                        <h3> ${data.main.temp}°C</h>
                        </div>
                        <div class="col">
                        <p>Basınç: ${data.main.pressure} hPa</p>
                        <p>Nem: ${data.main.humidity}%</p>
                        </div>
                        <div class="col">
                        <p>Hava: ${data.weather[0].description}</p>
                        <p>Gün Batımı: ${sunrise}</p>
                        </div>
                        </div>
                    </div>
                `);
            }
        });
    }
});


