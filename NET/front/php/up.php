<!DOCTYPE html>
<html>
<head>
    <title>Форма отправки POST-запроса</title>
</head>
<body>
    <h2>Отправка POST-запроса</h2>
    <form method="post" action="up_user.php">
        <label for="title">Заголовок:</label>
        <input type="text" id="title" name="title" value="<?php session_start(); echo $_SESSION['data']['title']; ?>" required>
        <br><br>
        <label for="login">Логин:</label>
        <input type="text" id="login" name="login" value="<?php echo $_SESSION['data']['login']; ?>" required>
        <br><br>
        <label for="password">Пароль:</label>
        <input type="password" id="password" name="password" value="<?php echo $_SESSION['data']['password']; ?>" required>
        <br><br>
        <label for="firstName">Имя:</label>
        <input type="text" id="firstName" name="firstName" value="<?php echo $_SESSION['data']['firstName']; ?>" required>
        <br><br>
        <label for="middleName">Отчество:</label>
        <input type="text" id="middleName" name="middleName" value="<?php echo $_SESSION['data']['middleName']; ?>" required>
        <br><br>
        <label for="lastName">Фамилия:</label>
        <input type="text" id="lastName" name="lastName" value="<?php echo $_SESSION['data']['lastName']; ?>" required>
        <br><br>
        <label for="mail">Адрес электронной почты:</label>
        <input type="email" id="mail" name="mail" value="<?php echo $_SESSION['data']['mail']; ?>" required>
        <br><br>
        <label for="numberPhone">Номер телефона:</label>
        <input type="text" id="numberPhone" name="numberPhone" value="<?php echo $_SESSION['data']['numberPhone']; ?>" required>
        <br><br>
        <input type="submit" value="Отправить">
    </form>
    <form method="post" action="del.php">
        <label for="id">ID:</label>
        <input type="text" id="id" name="id" value="<?php echo $_SESSION['id']?>" required>
        <br><br>
        <input type="submit" value="Удалить">
    </form>
    <p>
        <?php echo $_SESSION['response']; ?>
    </p>  
</body>
</html>