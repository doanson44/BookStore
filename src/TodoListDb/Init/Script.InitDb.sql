
IF NOT EXISTS( SELECT * FROM TodoItem)
BEGIN
INSERT INTO TodoItem VALUES 
(1, 'Wash the dishes', 15),
(2, 'vacuuming', 20),
(3, 'Learn some stuff on KA', 30)
END