--populate default data
BEGIN TRANSACTION;

USE final_capstone
GO

INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('A1', 0);
INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('A2', 0);
INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('A3', 0);
INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('A4', 0);
INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('A5', 0);
INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('B1', 0);
INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('B2', 0);
INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('B3', 0);
INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('B4', 0);
INSERT INTO parking_spots (parking_spot_id, parking_spot_status) VALUES ('B5', 0);

INSERT INTO parking_statuses (parking_status) VALUES ('Spot Requested');
INSERT INTO parking_statuses (parking_status) VALUES ('Parked');
INSERT INTO parking_statuses (parking_status) VALUES ('Spot Request Canceled');
INSERT INTO parking_statuses (parking_status) VALUES ('Pickup Requested');
INSERT INTO parking_statuses (parking_status) VALUES ('Picked Up');

COMMIT TRANSACTION;