--populate default data
BEGIN TRANSACTION;

USE final_capstone
GO

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

-- create a user with user role and a user with admin role
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

-- create some valets (password = password)
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('brianv','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','valet');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('jasonv','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','valet');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('juanv','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','valet');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('ericv','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','valet');
INSERT INTO valets (user_id, first_name, last_name) VALUES ((SELECT user_id FROM users WHERE username ='brianv'), 'Brian', 'LeMaster');
INSERT INTO valets (user_id, first_name, last_name) VALUES ((SELECT user_id FROM users WHERE username ='jasonv'), 'Jason', 'Picardi');
INSERT INTO valets (user_id, first_name, last_name) VALUES ((SELECT user_id FROM users WHERE username ='juanv'), 'Juan', 'Leon');
INSERT INTO valets (user_id, first_name, last_name) VALUES ((SELECT user_id FROM users WHERE username ='ericv'), 'Eric', 'Mast');
--
-- create the parking spots
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (0);

-- create the parking statuses
INSERT INTO parking_statuses (parking_status) VALUES ('Spot Requested');
INSERT INTO parking_statuses (parking_status) VALUES ('Parked');
INSERT INTO parking_statuses (parking_status) VALUES ('Spot Request Canceled');
INSERT INTO parking_statuses (parking_status) VALUES ('Pickup Requested');
INSERT INTO parking_statuses (parking_status) VALUES ('Picked Up');

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

INSERT INTO valet_slips (valet_id, license_plate, parking_spot_id, date, time_in, time_out, amount_owed, parking_status_id) VALUES (1, 'FBC623', 1, GETDATE(), (SELECT DATEADD(minute, -30, GETDATE())), '1753-1-1', 0, 1);
INSERT INTO valet_slips (valet_id, license_plate, parking_spot_id, date, time_in, time_out, amount_owed, parking_status_id) VALUES (1, 'GBC723',2, GETDATE(), (SELECT DATEADD(minute, -45, GETDATE())), '1753-1-1', 0, 1);
INSERT INTO valet_slips (valet_id, license_plate, parking_spot_id, date, time_in, time_out, amount_owed, parking_status_id) VALUES (1, 'IBC923', 3, GETDATE(), (SELECT DATEADD(minute, -15, GETDATE())), '1753-1-1', 0, 1);




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

COMMIT TRANSACTION;