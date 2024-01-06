<?php
session_start();
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Получение данных из формы
    $title = $_POST['title'];
    $login = $_POST['login'];
    $password = $_POST['password'];
    $firstName = $_POST['firstName'];
    $middleName = $_POST['middleName'];
    $lastName = $_POST['lastName'];
    $mail = $_POST['mail'];
    $numberPhone = $_POST['numberPhone'];
    //$response = $_POST['response'];

    // URL API для отправки POST-запроса
    $url = 'http://localhost:48945/User/user_select_login';

    // Данные для отправки в формате JSON
    $data = json_encode(array(
        'mail' => $login
    ));

    // Инициализация cURL
    $ch = curl_init($url);

    // Установка опций cURL
    curl_setopt($ch, CURLOPT_POST, 1);
    curl_setopt($ch, CURLOPT_POSTFIELDS, $data);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_HTTPHEADER, array(
        'Content-Type: application/json',
        'Content-Length: ' . strlen($data)
    ));

    // Выполнение запроса
    $rez = curl_exec($ch);
    $rezz = json_decode($rez, true);

    // Получение значения id
    $id = $rezz['id'];

    // Закрытие сессии cURL
    curl_close($ch);


    // Создание массива данных для отправки
    $data = array(
        "id" => $id,
        "title" => $title,
        "login" => $login,
        "password" => $password,
        "firstName" => $firstName,
        "middleName" => $middleName,
        "lastName" => $lastName,
        "mail" => $mail,
        "numberPhone" => $numberPhone,
        "isAdmin" => true,
        "dateDelete" => "2023-09-29T07:29:36.090141Z",
        "isDelete" => false,
        "cabinetId" => 30,
        "userStatusId" => 1
    );

    // Преобразование данных в формат JSON
    $jsonData = json_encode($data);

    // URL API для отправки POST-запроса
    $url1 = 'http://localhost:48945/User/user_update';

    // Инициализация cURL
    $ch = curl_init($url1);

    // Установка опций cURL
    curl_setopt($ch, CURLOPT_POST, 1);
    curl_setopt($ch, CURLOPT_POSTFIELDS, $jsonData);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_HTTPHEADER, array(
        'Content-Type: application/json',
        'Content-Length: ' . strlen($jsonData)
    ));

    // Выполнение запроса
    $response = curl_exec($ch);

    // Закрытие сессии cURL
    curl_close($ch);

    // Обработка ответа
    if ($response === false) {
        echo 'Ошибка выполнения запроса';
        header("Location: Index.php");
    } else {
        unset($_SESSION["data"]);
        $_SESSION["data"] = $data;
        $_SESSION["id"] = $id;
        header("Location: up.php?.$id");
    }
}
