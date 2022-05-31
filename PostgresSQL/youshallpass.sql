-- PROCEDURES/FUNCTIONS TABLA PLAYERS
CREATE OR REPLACE PROCEDURE sp_player_insert(first_name VARCHAR, last_name VARCHAR, email VARCHAR, age INT, country VARCHAR)
AS $$ 
	INSERT INTO players VALUES (DEFAULT, first_name, last_name, email, age, country, DEFAULT)
$$ LANGUAGE SQL;

CREATE OR REPLACE PROCEDURE sp_player_update(new_first_name VARCHAR, new_last_name VARCHAR, new_email VARCHAR, new_age INT, new_country VARCHAR)
AS $$ 
	UPDATE players SET 
	email = new_email,
	age = new_age,
	country = new_country,
	register_date = DEFAULT
	WHERE first_name = new_first_name AND last_name = new_last_name;
$$ LANGUAGE SQL;

CREATE OR REPLACE PROCEDURE sp_player_delete(dlt_first_name VARCHAR, dlt_last_name VARCHAR, dlt_email VARCHAR)
AS $$ 
	DELETE FROM players WHERE first_name = dlt_first_name AND last_name = dlt_last_name AND email = dlt_email
$$ LANGUAGE SQL;

CREATE OR REPLACE FUNCTION fn_player_hiscore(p_id INT)
RETURNS INT
AS $$ 
	SELECT MAX(score) 
	FROM games WHERE player_id = p_id;
$$ LANGUAGE SQL;

-- PROCEDURES/FUNCTIONS TABLA GAMES
CREATE OR REPLACE PROCEDURE sp_games_insert(game_score INT, game_time TIME, p_id INT)
AS $$ 
	INSERT INTO games VALUES (DEFAULT, game_score, DEFAULT, game_time, p_id)
$$ LANGUAGE SQL;

CREATE OR REPLACE PROCEDURE sp_games_delete(dlt_gameid INT)
AS $$ 
	DELETE FROM games WHERE game_id = dlt_gameid;
$$ LANGUAGE SQL;

CREATE OR REPLACE FUNCTION fn_topfive_scores()
RETURNS TABLE (playerid INT, highscore INT)
LANGUAGE plpgsql
AS $$
 	BEGIN
 	RETURN QUERY
	SELECT player_id, score
	FROM games
	ORDER BY score DESC
	LIMIT 5;
	END;
$$

CALL sp_player_insert('Diego', 'Pinones', 'diegopinones@gmail.com', 20, 'Mexico');
CALL sp_player_insert('Pedro', 'Picapiedra', 'pedropicapiedra@gmail.com', 20, 'Mexico');
CALL sp_player_insert('Alejandro', 'Garza', 'alejandrogarza@outlook.com', 47, 'Peru');
CALL sp_player_update('Diego','Pinones','pinonesdiego@gmail.com', 35, 'Japon');
CALL sp_player_delete('Diego', 'Pinones', 'pinonesdiego@gmail.com');

CALL sp_games_insert(400,'00:10:59',7);
CALL sp_games_insert(200,'00:11:35',7);
CALL sp_games_insert(150,'00:11:35',8);
CALL sp_games_insert(600,'00:11:35',9);
CALL sp_games_insert(1000,'00:11:35',8);
CALL sp_games_insert(50,'00:11:35',8);
CALL sp_games_insert(10,'00:11:35',9);
CALL sp_games_insert(160,'00:11:35',7);
CALL sp_games_delete(1);

SELECT fn_player_hiscore(7);
SELECT * FROM fn_topfive_scores();

SELECT * FROM players;
SELECT * FROM games;
DROP table games;
DROP table players;

CREATE TABLE players
(
    id SERIAL PRIMARY KEY NOT NULL,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(50),
    age INT,
    country VARCHAR(50),
    register_date DATE DEFAULT CURRENT_DATE
);

CREATE TABLE games
(
    game_id SERIAL PRIMARY KEY NOT NULL ,
    score INT,
    game_date DATE DEFAULT CURRENT_DATE,
    gametime TIME WITHOUT TIME ZONE,
    player_id SERIAL NOT NULL,
    CONSTRAINT fk_player_id
	FOREIGN KEY (player_id)
	REFERENCES players(id)
);

CREATE TABLE bitacora
(
	ids SERIAL, 
	first_name VARCHAR(50),
	last_name VARCHAR(50),
	time_log TIMESTAMP DEFAULT NOW()
);

-- A PARTIR DE AQUI NO ESTA MODIFICADO
CREATE OR REPLACE FUNCTION fn_ins_bitacora()
RETURNS TRIGGER AS $insertar$
DECLARE
BEGIN 
	INSERT INTO bitacora VALUES (OLD.ids,OLD.first_name);
	RETURN NULL;
END;
$insertar$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION fn_upd_bitacora()
RETURNS TRIGGER AS $insertar$
DECLARE
BEGIN 
	UPDATE bitacora SET nombre = OLD.nombre WHERE ids = OLD.ids;
	RETURN NULL;
END;
$insertar$ LANGUAGE plpgsql;

-- Trigger 1
CREATE TRIGGER tg_insertar_bitacora AFTER INSERT OR DELETE
ON users
FOR EACH ROW 
EXECUTE PROCEDURE fn_ins_bitacora();

-- Trigger 2 
CREATE TRIGGER tg_update_bitacora AFTER UPDATE
ON users
FOR EACH ROW 
EXECUTE PROCEDURE fn_ins_bitacora();




