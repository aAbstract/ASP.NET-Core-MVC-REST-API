USE CommanderApi;
GO
INSERT INTO Command (HowTo, Line, Platfrom)
VALUES
('cd', 'cd', 'Linux'),
('ifconfig', 'ifconfig', 'Linux'),
('systemctl status ssh', 'systemctl status ssh', 'Linux'),
('systemctl enable ssh', 'systemctl enable ssh', 'Linux');
GO
