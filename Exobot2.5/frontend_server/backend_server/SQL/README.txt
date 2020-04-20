
- add blank_bot.sql
- execute is_online.sql on it
- copy blank_bot db to bot_panel2
- add general.sql

- set password to admin user in bot_panel2/users/

How to make password: md5(YOUR_PASSWORD + PASSWORD_MD5_SALT)

PASSWORD_MD5_SALT is set in www/clients/panel2/bot/config_111.php