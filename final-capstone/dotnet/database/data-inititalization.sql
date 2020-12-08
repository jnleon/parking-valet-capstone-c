--populate default data
BEGIN TRANSACTION;

USE final_capstone
GO

-- test data for patrons
-- INSERT INTO patrons (user_id, first_name, last_name, phone_number,email_address) VALUES (1, 'Brian', 'LeMaster', '555-555-5555', 'blemaster@aol.com');

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

COMMIT TRANSACTION;