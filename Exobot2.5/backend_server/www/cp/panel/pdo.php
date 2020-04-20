<?php
# https://phpro.org/tutorials/Introduction-to-PHP-PDO.html

class Db
{
	public $conn;
	public $is_connected = false;
	private $dbg = false;
	public $sqls = array();
	
	public function connect($db_name, $db_user, $db_pass)
	{
		$this->sqls = array();
		
		try {
			$this->conn = new PDO("mysql:host=localhost;dbname=" . $db_name, $db_user, $db_pass);
			
			/*** set the error reporting attribute ***/
			$this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
			$this->is_connected = true;
		}catch(PDOException $e){
			//~ echo $e->getMessage();
		}
		
		return $this->is_connected;
	}
	
	function dbg($text)
	{
		if(!$this->dbg)
			return;
			
		file_put_contents('pdo.log', $text, FILE_APPEND);
	}
	
	// $ids = array(1, 2, 3, ...)
	// $this->db->exec_many("delete from bots where bot_id ?", $ids);
	function exec_many($sql, $values)
	{
		$sql = str_replace('?', "IN (" . join(",", array_fill(1, count($values), "?")) . ")", $sql);
		$this->sqls[] = $sql;
		$sth = $this->conn->prepare($sql);

		$sth->execute($values);
	}
	
	function quote($text, $param=PDO::PARAM_STR)
	{
		return $this->conn->quote($text, $param);
	}

	// quote and adds % -> '%text%'
	function quote_like($text, $param=PDO::PARAM_STR)
	{
		$text = $this->quote($text, $param);
		$text = "'%" .substr($text, 1, strlen($text)-2). "%'";
		return $text;
	}
	
	// param: array(name, value, PDO::type, max_length)
	// example: ':animal_name', $animal_name, PDO::PARAM_STR, 5
	// sql:  SELECT * FROM animals WHERE animal_id = :animal_id AND animal_name = :animal_name
	// PARAM_BOOL NULL INT STR - http://php.net/manual/en/pdo.constants.php
	function count()
	{
		return $this->exec("SELECT FOUND_ROWS()", null, true)[0][0];
	}
	
	// http://php.net/manual/en/pdostatement.fetch.php
	function exec($sql, $params=array(), $return=false, $fetch_type=PDO::FETCH_BOTH)
	{
		$this->sqls[] = $sql;
		$sth = $this->conn->prepare($sql);
		
		if(sizeof($params))
		foreach($params as $param)
		{
			if(sizeof($param) == 4)
				$sth->bindParam($param[0], $param[1], $param[2], $param[3]);
			else
				$sth->bindParam($param[0], $param[1], $param[2]);
		}

		$res = $sth->execute();

		$this->dbg("SQL: " . $sql . "; RESULT: " . $res);
		
		if($return)
			return $sth->fetchAll($fetch_type); // PDO::FETCH_ASSOC
	}

}
