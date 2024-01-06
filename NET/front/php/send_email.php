<?php
session_start();
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Получение данных из формы
    $comment = $_POST['comment'];
    $organisationInn = $_POST['organisationInn'];
    $organisationMail = $_POST['organisationMail'];
    $organisationTitle = $_POST['organisationTitle'];
    $cabinetStatusId = $_POST['cabinetStatusId'];
    $title = $_POST['title'];
    $login = $_POST['login'];
    $password = $_POST['password'];
    $firstName = $_POST['firstName'];
    $middleName = $_POST['middleName'];
    $lastName = $_POST['lastName'];
    $mail = $_POST['mail'];
    $numberPhone = $_POST['numberPhone'];

    // Создание массива данных для отправки
    $data = array(
        'comment' => $comment,
        'organisationInn' => $organisationInn,
        'organisationMail' => $organisationMail,
        'organisationTitle' => $organisationTitle,
        'cabinetStatusId' => $cabinetStatusId,
        'title' => $title,
        'login' => $login,
        'password' => $password,
        'firstName' => $firstName,
        'middleName' => $middleName,
        'lastName' => $lastName,
        'mail' => $mail,
        'numberPhone' => $numberPhone,
        "isAdmin" => true,
        "userStatusId" => 1
    );

    // Преобразование данных в формат JSON
    $jsonData = json_encode($data);

    // URL API для отправки POST-запроса
    $url = 'http://localhost:48945/Cabinet/cabinet_add_last_stage';

    // Инициализация cURL
    $ch = curl_init($url);

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
        echo $response;
        $_SESSION["data"] = $data;
        $_SESSION["response"] = $response;
        header("Location: up.php");
    }
}
?>