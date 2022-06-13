-- CREATE DATABASE 
CREATE DATABASE youshallpass;

-- ==========================
-- CREATE TABLES
CREATE TABLE players
(
   
id SERIAL PRIMARY KEY NOT NULL,
    nickname VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    age INT NOT NULL,
    country VARCHAR(50) NOT NULL,
    register_date DATE DEFAULT CURRENT_DATE
);

CREATE TABLE games
(
    game_id SERIAL PRIMARY KEY NOT NULL ,
    score INT,
    game_date DATE DEFAULT CURRENT_DATE,
    player_id SERIAL NOT NULL,
    CONSTRAINT fk_player_id
	FOREIGN KEY (player_id)
	REFERENCES players(id)
);

CREATE TABLE bitacora
(
	ids INT,
	operation char(1) NOT NULL,
	userid INT,
	nickname VARCHAR(50),
	time_log TIMESTAMP
);

-- ==========================
-- PROCEDURES/FUNCTIONS PLAYERS TABLE

-- INSERT
CREATE OR REPLACE PROCEDURE sp_player_insert(nnickname VARCHAR, nemail VARCHAR, nage INT, ncountry VARCHAR)
AS $$ 
	INSERT INTO players VALUES (DEFAULT, nnickname, nemail, nage, ncountry, DEFAULT)
$$ LANGUAGE SQL;

-- UPDATE
CREATE OR REPLACE PROCEDURE sp_player_update(nnickname VARCHAR, nemail VARCHAR, nage INT, ncountry VARCHAR)
AS $$ 
	UPDATE players SET 
	email = nemail,
	age = nage,
	country = ncountry,
	register_date = DEFAULT
	WHERE nickname = nnickname;
$$ LANGUAGE SQL;

-- DELETE
CREATE OR REPLACE PROCEDURE sp_player_delete(dnickname VARCHAR, demail VARCHAR)
AS $$ 
	DELETE FROM players WHERE nickname = dnickname AND email = demail
$$ LANGUAGE SQL;

-- QUERY HIGH SCORES 1 PLAYER
CREATE OR REPLACE FUNCTION fn_player_hiscore(p_id INT)
RETURNS TABLE (player_id INT ,score INT ,nickname VARCHAR)
LANGUAGE plpgsql
AS $$ 
	BEGIN
	RETURN QUERY
	SELECT games.player_id, games.score, players.nickname
	FROM games JOIN players on games.player_id = players.id WHERE players.id = p_id
	ORDER BY score DESC LIMIT 5;
	END;
$$;

-- ==========================
-- PROCEDURES/FUNCTIONS TABLA GAMES

-- INSERT
CREATE OR REPLACE PROCEDURE sp_games_insert(game_score INT, p_id INT)
AS $$ 
	INSERT INTO games VALUES (DEFAULT, game_score, DEFAULT, p_id)
$$ LANGUAGE SQL;

-- DELETE
CREATE OR REPLACE PROCEDURE sp_games_delete(dlt_gameid INT)
AS $$ 
	DELETE FROM games WHERE game_id = dlt_gameid;
$$ LANGUAGE SQL;

-- TOP 10 HIGHEST SCORES
CREATE OR REPLACE FUNCTION fn_topten_scores()
RETURNS TABLE (playerid INT, highscore INT, nickname VARCHAR)
LANGUAGE plpgsql
AS $$
 	BEGIN
	RETURN QUERY
	SELECT player_id, score, players.nickname
	FROM games JOIN players on games.player_id = players.id
	ORDER BY score DESC 
	LIMIT 10;
	END;
$$

-- SEQUENCE
CREATE SEQUENCE IF NOT EXISTS sq_bitacora_ids
INCREMENT 1	
START WITH 1 
OWNED BY bitacora.ids;

-- ==========================
-- ALTER TABLE bitacora
-- ALTER COLUMN ids SET DEFAULT nextval('sq_bitacora_ids');

-- TRIGGERS
CREATE OR REPLACE FUNCTION fn_details_bitacora()
RETURNS TRIGGER AS $$
BEGIN 
	IF (TG_OP = 'DELETE') THEN
		INSERT INTO bitacora
		SELECT nextval('sq_bitacora_ids'),'D',o.id,o.nickname,now() FROM old_table o;
	ELSIF (TG_OP = 'UPDATE') THEN
		INSERT INTO bitacora
		SELECT nextval('sq_bitacora_ids'),'U',n.id,n.nickname,now() FROM new_table n;
	ELSIF (TG_OP = 'INSERT') THEN
		INSERT INTO bitacora
		SELECT nextval('sq_bitacora_ids'),'I',n.id,n.nickname,now() FROM new_table n;
	END IF;
	RETURN NULL;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER details_bitacora_insert AFTER INSERT ON players
REFERENCING NEW TABLE AS new_table
FOR EACH STATEMENT EXECUTE FUNCTION fn_details_bitacora();

CREATE TRIGGER details_bitacora_update AFTER UPDATE ON players
REFERENCING NEW TABLE AS new_table
FOR EACH STATEMENT EXECUTE FUNCTION fn_details_bitacora();

CREATE TRIGGER details_bitacora_delete AFTER DELETE ON players
REFERENCING OLD TABLE AS old_table
FOR EACH STATEMENT EXECUTE FUNCTION fn_details_bitacora();

-- VIEWS
CREATE VIEW player_score_details AS 
SELECT player_id, score, players.nickname
	FROM games JOIN players on games.player_id = players.id
	ORDER BY score DESC;

-- INSERTS/DELETE/UPDATE DE PRUEBA
CALL sp_player_insert('Diego Pinones', 'diegopinones@gmail.com', 20, 'Mexico');
CALL sp_player_insert('Pedro Picapiedra', 'pedropicapiedra@gmail.com', 20, 'Mexico');
CALL sp_player_insert('Alejandro Garza', 'alejandrogarza@outlook.com', 47, 'Peru');
CALL sp_player_update('Diego Pinones','pinonesdiego@gmail.com', 35, 'Japon');
CALL sp_player_delete('Diego Pinones', 'pinonesdiego@gmail.com');
CALL sp_player_insert('Damian Gonzalez','damiangonzalez@gmail.com',17,'Colombia');
CALL sp_player_insert('Maria Perez','mariaperez@gmail.com',25,'Mexico');
CALL sp_player_delete('Maria Perez','mariaperez@gmail.com');
CALL sp_player_insert('Juan Martinez','juanmartinez@gmail.com',15,'Ecuador');
CALL sp_player_update('Juan Martinez','martinezjuan@gmail.com',16,'Mexico');

CALL sp_games_insert(400,2);
CALL sp_games_insert(200,2);
CALL sp_games_insert(150,4);
CALL sp_games_insert(600,3);
CALL sp_games_insert(1000,4);
CALL sp_games_insert(50,4);
CALL sp_games_insert(10,3);
CALL sp_games_insert(160,2);
CALL sp_games_delete(1);

SELECT * FROM fn_player_hiscore(4);
SELECT * FROM fn_topten_scores();

SELECT * FROM players;
SELECT * FROM games;
DROP table games;
DROP table players;

SELECT * FROM bitacora;
