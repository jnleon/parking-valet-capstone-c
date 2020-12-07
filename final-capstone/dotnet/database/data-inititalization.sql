--populate default data
BEGIN TRANSACTION;

USE final_capstone
GO

INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (1);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (1);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (1);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (1);
INSERT INTO parking_spots (is_occupied) VALUES (0);
INSERT INTO parking_spots (is_occupied) VALUES (1);

INSERT INTO parking_statuses (parking_status) VALUES ('Spot Requested');
INSERT INTO parking_statuses (parking_status) VALUES ('Parked');
INSERT INTO parking_statuses (parking_status) VALUES ('Spot Request Canceled');
INSERT INTO parking_statuses (parking_status) VALUES ('Pickup Requested');
INSERT INTO parking_statuses (parking_status) VALUES ('Picked Up');

COMMIT TRANSACTION;