USE final_capstone
GO

BEGIN TRANSACTION;

-- create some valets (password = password)
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('brianv','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','valet');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('jasonv','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','valet');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('juanv','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','valet');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('ericv','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','valet');
INSERT INTO valets (user_id, first_name, last_name) VALUES ((SELECT user_id FROM users WHERE username ='brianv'), 'Brian', 'LeMaster');
INSERT INTO valets (user_id, first_name, last_name) VALUES ((SELECT user_id FROM users WHERE username ='jasonv'), 'Jason', 'Picardi');
INSERT INTO valets (user_id, first_name, last_name) VALUES ((SELECT user_id FROM users WHERE username ='juanv'), 'Juan', 'Leon');
INSERT INTO valets (user_id, first_name, last_name) VALUES ((SELECT user_id FROM users WHERE username ='ericv'), 'Eric', 'Mast');

--Enter test data for users, patrons, vehicles, and valet slips
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Joe','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','patron');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Andy','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','patron');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Adam','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','patron');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Jose','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','patron');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('John','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','patron');

INSERT INTO patrons (user_id, first_name, last_name, phone_number,email_address) VALUES ((SELECT user_id FROM users WHERE username = 'Joe'),'Joe', 'Volpe', '555-555-5557', 'jvolpe@aol.com');
INSERT INTO patrons (user_id, first_name, last_name, phone_number,email_address) VALUES ((SELECT user_id FROM users WHERE username = 'John'),'John', 'Doe', '555-555-5558', 'jdoe@aol.com');
INSERT INTO patrons (user_id, first_name, last_name, phone_number,email_address) VALUES ((SELECT user_id FROM users WHERE username = 'Andy'),'Andy', 'Winger', '555-555-5559', 'awinger@aol.com');
INSERT INTO patrons (user_id, first_name, last_name, phone_number,email_address) VALUES ((SELECT user_id FROM users WHERE username = 'Adam'),'Adam', 'Smith', '555-555-5510', 'asmith@aol.com');
INSERT INTO patrons (user_id, first_name, last_name, phone_number,email_address) VALUES ((SELECT user_id FROM users WHERE username = 'Jose'),'Jose', 'Altuve', '555-555-5511', 'jaltuve@aol.com');

INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('FBC623',(SELECT patron_id FROM patrons WHERE email_address = 'jvolpe@aol.com'),'Pontiac','Trans Am','orange');
INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('GBC723',(SELECT patron_id FROM patrons WHERE email_address = 'jdoe@aol.com'),'Chevy','Chevelle','red');
INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('IBC923',(SELECT patron_id FROM patrons WHERE email_address = 'jaltuve@aol.com'),'Plymouth','Super Bird','orange');

INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('NEWCAR1',(SELECT patron_id FROM patrons WHERE email_address = 'awinger@aol.com'),'Chevy','Bolt','Grey');
INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('NEWCAR2',(SELECT patron_id FROM patrons WHERE email_address = 'asmith@aol.com'),'Tesla','Model3','White');


INSERT INTO valet_slips (valet_id, license_plate, parking_spot_id, date, time_in, time_out, amount_owed, parking_status_id) VALUES (1, 'NEWCAR1',null, GETDATE(), (SELECT DATEADD(minute, -20, GETDATE())), '1753-1-1', 0, 2);
INSERT INTO valet_slips (valet_id, license_plate, parking_spot_id, date, time_in, time_out, amount_owed, parking_status_id) VALUES (1, 'NEWCAR2', null, GETDATE(), (SELECT DATEADD(minute, -40, GETDATE())), '1753-1-1', 0, 2);



INSERT INTO valet_slips (valet_id, license_plate, parking_spot_id, date, time_in, time_out, amount_owed, parking_status_id) VALUES (1, 'FBC623', 1, GETDATE(), (SELECT DATEADD(minute, -30, GETDATE())), '1753-1-1', 0, 2);
INSERT INTO valet_slips (valet_id, license_plate, parking_spot_id, date, time_in, time_out, amount_owed, parking_status_id) VALUES (1, 'GBC723', 2, GETDATE(), (SELECT DATEADD(minute, -45, GETDATE())), '1753-1-1', 0, 2);
INSERT INTO valet_slips (valet_id, license_plate, parking_spot_id, date, time_in, time_out, amount_owed, parking_status_id) VALUES (1, 'IBC923', 3, GETDATE(), (SELECT DATEADD(minute, -15, GETDATE())), '1753-1-1', 0, 2);

UPDATE parking_spots SET is_occupied=1 WHERE parking_spot_id=1 OR parking_spot_id=2 OR parking_spot_id=3;

-- add cars to DB for testing
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('ABC123','100','Chevy','Camaro SS','red');
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('BBC223','101','Pontiac','GTO','black');
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('CBC323','102','Ford','Shelby Cobra','green');
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('DBC423','103','Chevy','Corvette','powder blue');
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('EBC523','104','Cadillac','El Dorado','black');
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('FBC623','105','Pontiac','Trans Am','orange');
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('GBC723','106','Chevy','Chevelle','red');
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('HBC823','107','Oldsmobile','442','cherry red');
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('IBC923','108','Plymouth','Super Bird','orange');
--INSERT INTO vehicles (license_plate, patron_id, vehicle_make, vehicle_model, vehicle_color) Values ('JBC023','109','AMC','AMX','green');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE patron_id ='brian'), 'Brian', 'LeMaster');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE username ='jason'), 'Jason', 'Picardi');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE username ='juan'), 'Juan', 'Leon');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE username ='eric'), 'Eric', 'Mast');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE username ='bob'), 'Bob', 'Smith');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE username ='joe'), 'Joe', 'Volpe');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE username ='john'), 'John', 'Doe');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE username ='andy'), 'Andy', 'Winger');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE username ='adam'), 'Adam', 'Smith');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number, email_address) VALUES ((SELECT patron_id FROM patrons WHERE username ='jose'), 'Jose', 'Altuve');

-- test data for patrons
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (100, 'Brian', 'LeMaster', '555-555-5552', 'blemaster@aol.com');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (101, 'Jason', 'Picardi', '555-555-5553', 'jpicardi@aol.com');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (102, 'Juan', 'Leon', '555-555-5554', 'jleon@aol.com');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (103, 'Eric', 'Mast', '555-555-5555', 'emast@aol.com');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (104, 'Bob', 'Smith', '555-555-5556', 'bsmith@aol.com');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (105, 'Joe', 'Volpe', '555-555-5557', 'jvolpe@aol.com');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (106, 'John', 'Doe', '555-555-5558', 'jdoe@aol.com');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (107, 'Andy', 'Winger', '555-555-5559', 'awinger@aol.com');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (108, 'Adam', 'Smith', '555-555-5510', 'asmith@aol.com');
--INSERT INTO patrons (patron_id, first_name, last_name, phone_number,email_address) VALUES (109, 'Jose', 'Altuve', '555-555-5511', 'jaltuve@aol.com');

COMMIT TRANSACTION;