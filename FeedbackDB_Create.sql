﻿CREATE TABLE Feedback
(
	Feedback_id INT NOT NULL PRIMARY KEY IDENTITY,
	Feedback_score INT NOT NULL,
	Feedback_createdAt DATETIME2 NOT NULL DEFAULT CURRENT_TIMESTAMP
);