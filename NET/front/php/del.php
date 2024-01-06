<?php
session_start();
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Получение данных из формы
    $id = $_POST['id'];

    // URL API для отправки POST-запроса
    $url = 'http://localhost:48945/User/d_u';

    // Данные для отправки в формате JSON
    $data = json_encode(array(
        'id' => intval($id)
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
