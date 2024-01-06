<!DOCTYPE HTML>


<?php
// URL API приложения на C#
$url = 'http://localhost:48945/User/user_auth';

// Данные для отправки в формате JSON
$data = json_encode(array(
    'mail' => 'trondin000@gmail.com'
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
$response = curl_exec($ch);

// Закрытие сессии cURL
curl_close($ch);

// Обработка ответа
if ($response === false) {
    echo 'Ошибка выполнения запроса';
} else {
    echo $response;
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Форма отправки POST-запроса</title>
</head>
<body>
    <h2>Отправка POST-запроса</h2>
    <form method="post" action="send_email.php">
        <label for="comment">Комментарий:</label>
        <input type="text" id="comment" name="comment" required>
        <br><br>
        <label for="organisationInn">ИНН организации:</label>
        <input type="text" id="organisationInn" name="organisationInn" required>
        <br><br>
        <label for="organisationMail">Почта организации:</label>
        <input type="email" id="organisationMail" name="organisationMail" required>
        <br><br>
        <label for="organisationTitle">Название организации:</label>
        <input type="text" id="organisationTitle" name="organisationTitle" required>
        <br><br>
        <label for="cabinetStatusId">Статус кабинета:</label>
        <input type="number" id="cabinetStatusId" name="cabinetStatusId" required>
        <br><br>
        <label for="title">Заголовок:</label>
        <input type="text" id="title" name="title" required>
        <br><br>
        <label for="login">Логин:</label>
        <input type="text" id="login" name="login" required>
        <br><br>
        <label for="password">Пароль:</label>
        <input type="password" id="password" name="password" required>
        <br><br>
        <label for="firstName">Имя:</label>
        <input type="text" id="firstName" name="firstName" required>
        <br><br>
        <label for="middleName">Отчество:</label>
        <input type="text" id="middleName" name="middleName" required>
        <br><br>
        <label for="lastName">Фамилия:</label>
        <input type="text" id="lastName" name="lastName" required>
        <br><br>
        <label for="mail">Адрес электронной почты:</label>
        <input type="email" id="mail" name="mail" required>
        <br><br>
        <label for="numberPhone">Номер телефона:</label>
        <input type="text" id="numberPhone" name="numberPhone" required>
        <br><br>
        <input type="submit" value="Отправить">
    </form>
</body>
</html>