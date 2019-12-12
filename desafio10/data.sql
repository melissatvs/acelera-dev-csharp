USE Codenation;

SET IDENTITY_INSERT [challenge] ON;
  INSERT INTO [challenge] ([id], [created_at], [name], [slug])
  VALUES (1, '2019-04-16T13:11:18.0000000', N'Lutra canadensis', N'cmingaud0-celtun0'),
  (2, '2019-05-23T13:05:49.0000000', N'Merops nubicus', N'chicken1-iwhyard1'),
  (3, '2018-09-02T11:06:17.0000000', N'Alligator mississippiensis', N'mrackley2-apohling2'),
  (4, '2019-01-01T21:14:36.0000000', N'Phacochoerus aethiopus', N'adiclaudio3-ssculpher3'),
  (5, '2019-05-31T08:44:10.0000000', N'Phalacrocorax brasilianus', N'agobel4-mramiro4'),
  (6, '2019-04-16T23:23:59.0000000', N'Tauraco porphyrelophus', N'farrowsmith5-tchicotti5'),
  (7, '2018-12-02T00:44:22.0000000', N'Naja sp.', N'balvarado6-seagling6'),
  (8, '2018-11-11T22:46:26.0000000', N'Equus burchelli', N'hpilmer7-svanyashkin7'),
  (9, '2018-12-06T07:47:04.0000000', N'Deroptyus accipitrinus', N'sstreatfield8-rchilcotte8'),
  (10, '2019-08-16T03:17:57.0000000', N'Choriotis kori', N'dellingsworth9-gpointing9');
SET IDENTITY_INSERT [challenge] OFF;

SET IDENTITY_INSERT [company] ON;
  INSERT INTO [company] ([id], [created_at], [name], [slug])
  VALUES (10, '2018-11-03T08:31:36.0000000', N'Little, Pfannerstill and Harris', N'rjurczak9-egillings9'),
  (9, '2018-10-21T15:30:28.0000000', N'Cormier Group', N'ckovelmann8-rkrop8'),
  (8, '2019-03-04T20:47:38.0000000', N'D''Amore, Carter and Cremin', N'elesor7-ctemlett7'),
  (7, '2019-03-06T13:41:59.0000000', N'Wiegand-Zboncak', N'uguwer6-ibarnham6'),
  (6, '2019-06-22T22:02:15.0000000', N'Mohr, Schoen and Bogisich', N'mgreve5-troadknight5'),
  (5, '2019-01-09T12:28:27.0000000', N'Sipes and Sons', N'bdubarry4-medgeller4'),
  (4, '2019-02-11T09:02:39.0000000', N'Sanford, Anderson and Bernhard', N'dwaby3-cvarlow3'),
  (3, '2018-12-28T10:20:48.0000000', N'Schuster, Hoeger and Abshire', N'vlorenzin2-bvitall2'),
  (2, '2019-04-30T02:41:10.0000000', N'Halvorson LLC', N'pmattack1-hsantus1'),
  (1, '2019-06-13T23:22:48.0000000', N'Keeling-Ward', N'dgirardoni0-jscola0');
SET IDENTITY_INSERT [company] OFF;

SET IDENTITY_INSERT [user] ON;
  INSERT INTO [user] ([id], [created_at], [email], [full_name], [nickname], [password])
  VALUES (1, '2019-06-17T06:35:28.0000000', N'ccapaldi0@exblog.jp', N'Chlo Capaldi', N'Chlo', N'coOuP45ZbK'),
  (2, '2018-08-25T17:45:58.0000000', N'vcowwell1@lycos.com', N'Vivia Cowwell', N'Vivia', N'KA9yknYe'),
  (3, '2019-06-06T22:01:28.0000000', N'owynn2@themeforest.net', N'Osborne Wynn', N'Osborne', N'XU3ydNp8iv8'),
  (4, '2019-01-24T23:13:40.0000000', N'mterne3@home.pl', N'Moyna Terne', N'Moyna', N'JHoTNdcCCAp'),
  (5, '2018-10-16T03:16:12.0000000', N'msteanyng4@japanpost.jp', N'Mignon Steanyng', N'Mignon', N'ypUHWMV0Kuh'),
  (6, '2018-09-01T04:43:42.0000000', N'rsegoe5@yale.edu', N'Rona Segoe', N'Rona', N'iJCbvUEJX'),
  (7, '2018-11-05T07:31:44.0000000', N'nchisnell6@zimbio.com', N'Norbie Chisnell', N'Norbie', N'T5RF38a'),
  (8, '2019-03-20T06:44:17.0000000', N'ptoffetto7@theguardian.com', N'Peg Toffetto', N'Peg', N'TV06FxQ'),
  (9, '2019-04-29T21:25:57.0000000', N'sredihough8@java.com', N'Susy Redihough', N'Susy', N'Uw4xwhMJNp'),
  (10, '2018-08-27T15:55:27.0000000', N'tegglestone9@blog.com', N'Tim Egglestone', N'Tim', N'2epRrOi');
SET IDENTITY_INSERT [user] OFF;

SET IDENTITY_INSERT [acceleration] ON;
  INSERT INTO [acceleration] ([id], [challenge_id], [created_at], [name], [slug])
  VALUES (1, 2, '2019-05-13T00:58:05.0000000', N'Velvet Grass', N'shuge1-gmcgauhy1'),
  (2, 3, '2019-06-18T10:47:40.0000000', N'Progesterone', N'tinkster2-sedsall2'),
  (3, 5, '2018-11-10T09:45:27.0000000', N'Temazepam', N'oantognetti4-bivashintsov4'),
  (4, 10, '2019-05-18T10:14:05.0000000', N'Stool Softener', N'cdishman9-mvinall9');
SET IDENTITY_INSERT [acceleration] OFF;

  INSERT INTO [submission] ([user_id], [challenge_id], [created_at], [score])
  VALUES (7, 7, '2018-10-03T02:06:59.0000000', 58.9),
  (6, 6, '2018-12-12T18:25:55.0000000', 33.97),
  (5, 8, '2019-04-28T06:38:22.0000000', 40.33),
  (5, 6, '2018-09-01T14:07:08.0000000', 23.5),
  (5, 5, '2019-05-22T13:17:08.0000000', 56.6),
  (4, 7, '2018-11-13T05:17:34.0000000', 4.27),
  (4, 5, '2019-06-23T03:35:40.0000000', 21.66),
  (4, 4, '2019-06-01T20:50:30.0000000', 5.66),
  (3, 4, '2018-08-27T20:26:12.0000000', 90.08),
  (8, 8, '2019-01-03T10:20:24.0000000', 43.2),
  (3, 3, '2019-03-20T11:22:20.0000000', 26.81),
  (2, 5, '2018-12-25T18:25:58.0000000', 58.67),
  (2, 3, '2018-09-01T22:13:02.0000000', 79.22),
  (2, 2, '2019-08-05T05:28:00.0000000', 1.19),
  (1, 4, '2019-03-20T01:37:53.0000000', 31.7),
  (1, 2, '2019-04-02T11:41:42.0000000', 50.0),
  (1, 1, '2019-08-08T07:34:56.0000000', 91.13),
  (3, 6, '2019-01-23T04:22:01.0000000', 67.08),
  (9, 9, '2018-12-18T16:00:43.0000000', 51.18);

  INSERT INTO [candidate] ([user_id], [acceleration_id], [company_id], [created_at], [status])
  VALUES (1, 1, 1, '2019-06-10T18:10:43.0000000', 2),
  (1, 4, 1, '2019-01-04T01:21:18.0000000', 1),
  (4, 4, 4, '2019-01-14T14:20:39.0000000', 2),
  (7, 3, 7, '2019-04-22T02:55:25.0000000', 1),
  (5, 3, 5, '2019-08-04T22:15:40.0000000', 2),
  (3, 3, 2, '2018-08-23T20:06:53.0000000', 2),
  (2, 3, 1, '2019-01-11T12:51:23.0000000', 5),
  (1, 3, 1, '2018-10-20T21:16:17.0000000', 2),
  (3, 3, 3, '2018-09-04T08:52:21.0000000', 3),
  (6, 2, 6, '2018-10-27T09:14:21.0000000', 5),
  (5, 2, 5, '2019-02-05T15:06:35.0000000', 4),
  (1, 2, 1, '2019-03-23T02:31:49.0000000', 2),
  (2, 2, 2, '2019-03-06T04:21:52.0000000', 1),
  (9, 1, 9, '2019-04-10T17:32:35.0000000', 2),
  (8, 1, 8, '2019-07-22T06:07:46.0000000', 3),
  (7, 1, 7, '2018-09-01T04:21:00.0000000', 5),
  (6, 1, 6, '2018-08-24T16:06:08.0000000', 3),
  (5, 1, 5, '2019-08-11T17:31:33.0000000', 5),
  (2, 4, 1, '2019-08-10T07:30:46.0000000', 5),
  (3, 4, 2, '2019-02-08T02:31:33.0000000', 2);
