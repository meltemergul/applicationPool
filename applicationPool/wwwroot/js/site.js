﻿$(document).ready(function () {
    const majorCities = ["London", "İstanbul", "Berlin", "Paris"];

    // Fetch weather for major cities on page load
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
                    <div class="col-sm-5 text-white rounded" style="background-color:skyblue; margin:5px " class="cityWeather">
                        <h2>${data.name}</h2>
                   
                        <div class="row">
                        <div class="col">     <img src="${iconUrl}" alt="Weather icon" width="100px" height="100px">
                        <h2> ${data.main.temp}°C</h2>  </div>
                        <div class="col"> <p>Basınç: ${data.main.pressure} hPa</p>
                        <p>Nem: ${data.main.humidity}%</p></div>
                        <div class="col"><p>Hava: ${data.weather[0].description}</p>
                        <p>Gündoğumu: ${sunrise}</p></div>
                        </div>
                       
                        
                 
                    </div>
                `);
            }
        });
    }
});


