function calculate(model, color, width, height) {
	let colorCode = 0;	//default color
	let modelCode = 0; // default model
	let totalPrice = 0;

	let models = ["Стандарт",
		"Елеганс",
		"Вера",
		"Престиж",
		"Класик",
		"Смарт",
		"Кабрио",
		"Балконски",
		"Кристал",
		"Кристал РИДО"
	];

	let colors = ["Breza", "Para"];

	let modelsTable =
		[
			[
				//standart //0
				[793, 917, 972, 1027, 1150, 1205, 1397],
				[0, 1000, 1057, 1114, 1252, 1308, 1517],
				[0, 0, 1128, 1186, 1343, 1399, 1627],
				[0, 0, 0, 1283, 1456, 1515, 1757]
			],
			[         //1
				[887, 1033, 1093, 1154, 1299, 1358, 1578],
				[0, 1129, 1192, 1254, 1418, 1480, 1721],
				[0, 0, 1277, 1340, 1525, 1588, 1850],
				[0, 0, 0, 1453, 1660, 1724, 2005]
			],
			[        //2
				[946, 1114, 1175, 1236, 1403, 1466, 1710],
				[0, 1227, 1290, 1353, 1546, 1609, 1879],
				[0, 0, 1390, 1454, 1673, 1738, 2033],
				[0, 0, 0, 1584, 1829, 1894, 2216]
			],
			[
				//Elegance       //3
				[1017, 1138, 1208, 1277, 1398, 1468, 1675, 1984, 2132, 2339, 2409],
				[0, 1204, 1275, 1345, 1479, 1550, 1771, 2093, 2242, 2462, 2533],
				[0, 0, 1369, 1441, 1588, 1660, 1894, 2243, 2393, 2627, 2699],
				[0, 0, 0, 1623, 1783, 1942, 2103, 2176, 2674, 2834, 2907],
				[0, 0, 0, 0, 2030, 2105, 2278, 2352, 2504, 3076, 0],
				[0, 0, 0, 0, 0, 2134, 2493, 2569, 2722, 0, 0]
			],
			[                   //4
				[1088.19, 1217.66, 1292.56, 1366.39, 1495.86, 1570.76, 1792.25, 2122.88, 2281.24, 2502.73, 2577.63],
				[0.00, 1288.28, 1364.25, 1439.15, 1582.53, 1658.50, 1894.97, 2239.51, 2398.94, 2634.34, 2710.31],
				[0.00, 0.00, 1464.83, 1541.87, 1699.16, 1776.20, 2026.58, 2400.01, 2560.51, 2810.89, 2887.93],
				[0.00, 0.00, 0.00, 1736.61, 1907.81, 2077.94, 2250.21, 2328.32, 2861.18, 3032.38, 3110.49],
				[0.00, 0.00, 0.00, 0.00, 2172.10, 2252.35, 2437.46, 2516.64, 2679.28, 3291.32, 0.00],
				[0.00, 0.00, 0.00, 0.00, 0.00, 2283.38, 2667.51, 2748.83, 2912.54, 0.00, 0.00]
			],
			[                   //5
				[1169.55, 1308.70, 1389.20, 1468.55, 1607.70, 1688.20, 1926.25, 2281.60, 2451.80, 2689.85, 2770.35],
				[0.00, 1384.60, 1466.25, 1546.75, 1700.85, 1782.50, 2036.65, 2406.95, 2578.30, 2831.30, 2912.95],
				[0.00, 0.00, 1574.35, 1657.15, 1826.20, 1909.00, 2178.10, 2579.45, 2751.95, 3021.05, 3103.85],
				[0.00, 0.00, 0.00, 1866.45, 2050.45, 2233.30, 2418.45, 2502.40, 3075.10, 3259.10, 3343.05],
				[0.00, 0.00, 0.00, 0.00, 2334.50, 2420.75, 2619.70, 2704.80, 2879.60, 3537.40, 0.00],
				[0.00, 0.00, 0.00, 0.00, 0.00, 2454.10, 2866.95, 2954.35, 3130.30, 0.00, 0.00]
			],
			[
				//Vera          //6
				[1499, 1710, 1869, 2028, 2239, 2398, 2712],
				[0, 0, 1958, 2118, 2342, 2502, 2830],
				[0, 0, 0, 2218, 2455, 2617, 2957],
				[0, 0, 0, 0, 2571, 2734, 3088]
			],
			[                   //7
				[1573.95, 1795.50, 1962.45, 2129.40, 2350.95, 2517.90, 2847.60],
				[0.00, 0.00, 2055.90, 2223.90, 2459.10, 2627.10, 2971.50],
				[0.00, 0.00, 0.00, 2328.90, 2577.75, 2747.85, 3104.85],
				[0.00, 0.00, 0.00, 0.00, 2699.55, 2870.70, 3242.40]
			],
			[                 //8
				[1648.90, 1881.00, 2055.90, 2230.80, 2462.90, 2637.80, 2983.20],
				[0.00, 0.00, 2153.80, 2329.80, 2576.20, 2752.20, 3113.00],
				[0.00, 0.00, 0.00, 2439.80, 2700.50, 2878.70, 3252.70],
				[0.00, 0.00, 0.00, 0.00, 2828.10, 3007.40, 3396.80]
			],
			[
				//Prestige   //9
				[1945, 2187, 2378, 2570, 2812, 3003, 3246, 3938, 4211, 4453, 4645],
				[0, 2283, 2476, 2668, 2923, 3116, 3371, 4153, 4428, 4683, 4875],
				[0, 0, 2576, 2770, 3038, 3232, 3500, 4313, 4588, 4856, 5134],
				[0, 0, 0, 2879, 3159, 3439, 3720, 3915, 4843, 5124, 0]
			],
			[               //10
				[2042.25, 2296.35, 2496.90, 2698.50, 2952.60, 3153.15, 3408.30, 4134.90, 4421.55, 4675.65, 4877.25],
				[0.00, 2397.15, 2599.80, 2801.40, 3069.15, 3271.80, 3539.55, 4360.65, 4649.40, 4917.15, 5118.75],
				[0.00, 0.00, 2704.80, 2908.50, 3189.90, 3393.60, 3675.00, 4528.65, 4817.40, 5098.80, 5390.70],
				[0.00, 0.00, 0.00, 3022.95, 3316.95, 3610.95, 3906.00, 4110.75, 5085.15, 5380.20, 0.00]
			],
			[               //11
				[2139.50, 2405.70, 2615.80, 2827.00, 3093.20, 3303.30, 3570.60, 4331.80, 4632.10, 4898.30, 5109.50],
				[0.00, 2511.30, 2723.60, 2934.80, 3215.30, 3427.60, 3708.10, 4568.30, 4870.80, 5151.30, 5362.50],
				[0.00, 0.00, 2833.60, 3047.00, 3341.80, 3555.20, 3850.00, 4744.30, 5046.80, 5341.60, 5647.40],
				[0.00, 0.00, 0.00, 3166.90, 3474.90, 3782.90, 4092.00, 4306.50, 5327.30, 5636.40, 0.00]
			],
			[
				//Classic   //12
				[784, 875, 928, 1019, 1071, 1123, 1214],
				[811, 914, 967, 1071, 1124, 1177, 1281],
				[834, 950, 1004, 1120, 1174, 1229, 1344],
				[860, 989, 1044, 1172, 1228, 1283, 1411],
				[884, 1024, 1081, 1221, 1278, 1334, 1475]
			],
			[                //13
				[823.20, 918.75, 974.40, 1069.95, 1124.55, 1179.15, 1274.70],
				[851.55, 959.70, 1015.35, 1124.55, 1180.20, 1235.85, 1345.05],
				[875.70, 997.50, 1054.20, 1176.00, 1232.70, 1290.45, 1411.20],
				[903.00, 1038.45, 1096.20, 1230.60, 1289.40, 1347.15, 1481.55],
				[928.20, 1075.20, 1135.05, 1282.05, 1341.90, 1400.70, 1548.75]
			],
			[               //14
				[862.40, 962.50, 1020.80, 1120.90, 1178.10, 1235.30, 1335.40],
				[892.10, 1005.40, 1063.70, 1178.10, 1236.40, 1294.70, 1409.10],
				[917.40, 1045.00, 1104.40, 1232.00, 1291.40, 1351.90, 1478.40],
				[946.00, 1087.90, 1148.40, 1289.20, 1350.80, 1411.30, 1552.10],
				[972.40, 1126.40, 1189.10, 1343.10, 1405.80, 1467.40, 1622.50]
			],
			[
				//Smart    //15
				[793, 939, 1043, 1189, 1294, 1399, 1544],
				[821, 980, 1086, 1244, 1350, 1456, 1615],
				[845, 1017, 1124, 1296, 1403, 1510, 1682],
				[873, 1058, 1167, 1352, 1460, 1568, 1753],
				[898, 1096, 1205, 1404, 1513, 1622, 1820]
			],
			[               //16
				[832.65, 985.95, 1095.15, 1248.45, 1358.70, 1468.95, 1621.20],
				[862.05, 1029.00, 1140.30, 1306.20, 1417.50, 1528.80, 1695.75],
				[887.25, 1067.85, 1180.20, 1360.80, 1473.15, 1585.50, 1766.10],
				[916.65, 1110.90, 1225.35, 1419.60, 1533.00, 1646.40, 1840.65],
				[942.90, 1150.80, 1265.25, 1474.20, 1588.65, 1703.10, 1911.00]
			],
			[               //17
				[872.30, 1032.90, 1147.30, 1307.90, 1423.40, 1538.90, 1698.40],
				[903.10, 1078.00, 1194.60, 1368.40, 1485.00, 1601.60, 1776.50],
				[929.50, 1118.70, 1236.40, 1425.60, 1543.30, 1661.00, 1850.20],
				[960.30, 1163.80, 1283.70, 1487.20, 1606.00, 1724.80, 1928.30],
				[987.80, 1205.60, 1325.50, 1544.40, 1664.30, 1784.20, 2002.00]
			],
			[
				//Kabrio   //18
				[498, 601, 667, 753, 855, 922, 1044, 1110],
				[715, 783, 914, 1001, 1131, 1199, 1286, 1416],
				[985, 1054, 1212, 1301, 1371, 1528, 1617, 0],
				[1306, 1377, 1448, 1653, 1724, 1910, 0, 0]
			],
			[             //19
				[498, 601, 667, 753, 855, 922, 1044, 1110],
				[715, 783, 914, 1001, 1131, 1199, 1286, 1416],
				[985, 1054, 1212, 1301, 1371, 1528, 1617, 0],
				[1306, 1377, 1448, 1653, 1724, 1910, 0, 0]
			],
			[             //20
				[547.80, 661.10, 733.70, 828.30, 940.50, 1014.20, 1148.40, 1221.00],
				[786.50, 861.30, 1005.40, 1101.10, 1244.10, 1318.90, 1414.60, 1557.60],
				[1083.50, 1159.40, 1333.20, 1431.10, 1508.10, 1680.80, 1778.70, 0.00],
				[1436.60, 1514.70, 1592.80, 1818.30, 1896.40, 2101.00, 0.00, 0.00]
			],
			[
				//Balkonski //21
				[400, 504, 543, 647, 686, 726, 829, 869, 1045, 1085, 1125]
			],
			[             //22
				[440.00, 554.40, 597.30, 711.70, 754.60, 798.60, 911.90, 955.90, 1149.50, 1193.50, 1237.50]
			],
			[             //23
				[500.00, 630.00, 678.75, 808.75, 857.50, 907.50, 1036.25, 1086.25, 1306.25, 1356.25, 1406.25]
			],
			[
				//Kristal // 24
				[330.00, 424.80, 520.80, 616.80, 711.60, 807.60],
				[356.40, 468.00, 578.40, 688.80, 799.20, 909.60],
				[384.00, 510.00, 636.00, 760.80, 886.80, 1012.80],
				[411.60, 552.00, 692.40, 834.00, 974.40, 1114.80]
			],
			[
				//Kristal Rido  //25
				[576.40, 713.90, 851.40, 990.00, 1127.50, 1265.00],
				[697.40, 847.00, 996.60, 1147.30, 1296.90, 1446.50],
				[817.30, 980.10, 1141.80, 1304.60, 1466.30, 1629.10],
				[938.30, 1113.20, 1287.00, 1461.90, 1636.80, 1810.60],
				[1059.30, 1245.20, 1432.20, 1619.20, 1806.20, 1992.10],
				[1179.20, 1378.30, 1577.40, 1776.50, 1975.60, 2174.70]
			]
		];

	getColor();
	getModel();
	return printFinalPrice();

	function getColor() {
		colorCode = colors.indexOf(color);
	}

	function getModel() {
		modelCode = models.indexOf(model);
		switch (modelCode) {
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 8:
			case 9:
				break;
			case 6:
				break;
			case 7:
				break;
			default:
				break;
		}
	}

	// MAXIMUM
	function throwMaxLenghtExeption(wOrH, maximum) {
		let maxWidth = "Масималната ширина на този сенник е ";
		let maxHeight = "Максималната височина(напред) на този сенник е ";
		if (wOrH == 0)	// Width
		{
			return maxWidth + maximum + ' cm.';
		}
		else	// e.g. 1 -> height
		{
			return maxHeight + maximum + ' cm.';
		}
	}

	// MINIMUM
	function throwMinLenghtExeption(minimum) {
		let minWidth = "Минималната ширина на този сенник е ";
		return minWidth + minimum + ' cm.';
	}

	function findTable(model, color) {
		let tableIndex = 0;
		switch (model) {
			case 0:                 //standart
				tableIndex = 0;
				break;
			case 1:                 //elegance
				tableIndex = 3;
				break;
			case 2:                 //vera
				tableIndex = 6;
				break;
			case 3:                 //prestige
				tableIndex = 9;
				break;
			case 4:                 //classic
				tableIndex = 12;
				break;
			case 5:                 //smart
				tableIndex = 15;
				break;
			case 6:                 //cabrio
				tableIndex = 18;
				break;
			case 7:                 //balkonski
				tableIndex = 21;
				break;
			case 8:                 //kristal
				tableIndex = 24;
				break;
			case 9:                 //kristal rido
				tableIndex = 25;
				break;
		}

		if (model != 8 && 9) {
			tableIndex += color;
		}


		return tableIndex;
	}

	function findPriceClasicAndSmart(height, width) {
		let error = undefined;
		let row = 0;
		let col = 0;
		let total = 0;
		let dimention = findTable(modelCode, colorCode);
		//-------- Width Parameters
		if (width < 70) {
		    error = throwMinLenghtExeption(70);
		}
		if (width > 400) {
			error = throwMaxLenghtExeption(0, 400);
			return 1;
		}
		if (width > 350) {
			col = 6;
		}
		else if (width > 300) {
			col = 5;
		}
		else if (width > 250) {
			col = 4;
		}
		else if (width > 200) {
			col = 3;
		}
		else if (width > 150) {
			col = 2;
		}
		else if (width > 100) {
			col = 1;
		}
		else {
			col = 0;
		}
		//------- Lenght/Height Parameters
		if (height > 150) {
			error = throwMaxLenghtExeption(1, 150);
			return 1;
		}
		if (height > 125) {
			row = 4;
		}
		else if (height > 100) {
			row = 3;
		}
		else if (height > 75) {
			row = 2;
		}
		else if (height > 50) {
			row = 1;
		}
		else {
			row = 0;
		}

		if (error !== undefined) {
			return error;
        }

		total = modelsTable[dimention][row][col];
		return total;
	}

	function findPriceStandartAndVera(height, width) {
		let error = undefined;
		let row = 0;
		let col = 0;
		let total = 0;
		let dimention = findTable(modelCode, colorCode);
		//-------- Width Parameters
		if (width < 185) {
			error = throwMinLenghtExeption(185);
		}
		if (width > 500) {
			error = throwMaxLenghtExeption(0, 500);
			return 1;
		}
		if (width > 450) {
			col = 6;
		}
		else if (width > 400) {
			col = 5;
		}
		else if (width > 350) {
			col = 4;
		}
		else if (width > 300) {
			col = 3;
		}
		else if (width > 250) {
			col = 2;
		}
		else if (width > 200) {
			col = 1;
		}
		else {
			col = 0;
		}
		//------- Lenght/Height Parameters
		if (height < 50 || height > 300) {
			error = throwMaxLenghtExeption(1, 300);
			return 1;
		}
		if (height > 250) {
			row = 3;
		}
		else if (height > 200) {
			row = 2;
		}
		else if (height > 150) {
			row = 1;
		}
		else {
			row = 0;
		}

		if (error !== undefined) {
			return error;
		}

		total = modelsTable[dimention][row][col];
		return total;
	}

	function findPriceElegans(height, width) {
		let error = undefined;
		let row = 0;
		let col = 0;
		let total = 0;
		let dimention = findTable(modelCode, colorCode);
		//-------- Width Parameters
		if (width < 185) {
			error = throwMinLenghtExeption(185);
		}
		if (width > 700) {
			error = throwMaxLenghtExeption(0, 700);
			return 1;
		}

		if (width > 650) {
			col = 10;
		}
		else if (width > 600) {
			col = 9;
		}
		else if (width > 550) {
			col = 8;
		}
		else if (width > 500) {
			col = 7;
		}
		else if (width > 450) {
			col = 6;
		}
		else if (width > 400) {
			col = 5;
		}
		else if (width > 350) {
			col = 4;
		}
		else if (width > 300) {
			col = 3;
		}
		else if (width > 250) {
			col = 2;
		}
		else if (width > 200) {
			col = 1;
		}
		else {
			col = 0;
		}
		//------- Lenght/Height Parameters
		if (height > 400) {
			error = throwMaxLenghtExeption(1, 400);
			return 1;
		}

		if (height > 350) {
			row = 5;
		}
		else if (height > 300) {
			row = 4;
		}
		else if (height > 250) {
			row = 3;
		}
		else if (height > 200) {
			row = 2;
		}
		else if (height > 150) {
			row = 1;
		}
		else {
			row = 0;
		}

		if (error !== undefined) {
			return error;
		}

		total = modelsTable[dimention][row][col];
		return total;
	}

	function findPricePrestige(height, width) {
		let row = 0;
		let col = 0;
		let total = 0;
		let dimention = findTable(modelCode, colorCode);
		//-------- Width Parameters
		if (width < 185) {
			throwMinLenghtExeption(185);
		}
		if (width > 700) {
			throwMaxLenghtExeption(0, 700);
			return 1;
		}

		if (width > 650) {
			col = 10;
		}
		else if (width > 600) {
			col = 9;
		}
		else if (width > 550) {
			col = 8;
		}
		else if (width > 500) {
			col = 7;
		}
		else if (width > 450) {
			col = 6;
		}
		else if (width > 400) {
			col = 5;
		}
		else if (width > 350) {
			col = 4;
		}
		else if (width > 300) {
			col = 3;
		}
		else if (width > 250) {
			col = 2;
		}
		else if (width > 200) {
			col = 1;
		}
		else {
			col = 0;
		}
		//------- Lenght/Height Parameters
		if (height > 300) {
			throwMaxLenghtExeption(1, 300);
			return 1;
		}
		if (height > 250) {
			row = 3;
		}
		else if (height > 200) {
			row = 2;
		}
		else if (height > 150) {
			row = 1;
		}
		else {
			row = 0;
		}

		total = modelsTable[dimention][row][col];
		return total;
	}

	function findPriceCabrio(height, width) {
		let row = 0;
		let col = 0;
		let total = 0;
		let dimention = findTable(modelCode, colorCode);
		//-------- Width Parameters
		if (width < 70) {
			throwMinLenghtExeption(70);
		}
		if (width > 450) {
			throwMaxLenghtExeption(0, 450);
			return 1;
		}
		else if (width > 400) {
			col = 7;
		}
		else if (width > 350) {
			col = 6;
		}
		else if (width > 300) {
			col = 5;
		}
		else if (width > 250) {
			col = 4;
		}
		else if (width > 200) {
			col = 3;
		}
		else if (width > 150) {
			col = 2;
		}
		else if (width > 100) {
			col = 1;
		}
		else {
			col = 0;
		}
		//------- Lenght/Height Parameters
		if (height > 200) {
			throwMaxLenghtExeption(1, 200);
			return 1;
		}
		else if (height > 150) {
			row = 3;
		}
		else if (height > 100) {
			row = 2;
		}
		else if (height > 50) {
			row = 1;
		}
		else {
			row = 0;
		}

		total = modelsTable[dimention][row][col];
		return total;
	}

	function findPriceBalkonski(height, width) {
		// The lenght is olny 200 cm and the field is disabled
		let row = 0;
		let col = 0;
		let total = 0;
		let dimention = findTable(modelCode, colorCode);

		if (width < 70) {
			throwMinLenghtExeption(70);
		}

		if (width > 600) {
			throwMaxLenghtExeption(0, 600);
			return 1;
		}
		else if (width > 550) {
			col = 10;
		}
		else if (width > 500) {
			col = 9;
		}
		else if (width > 450) {
			col = 8;
		}
		else if (width > 400) {
			col = 7;
		}
		else if (width > 350) {
			col = 6;
		}
		else if (width > 300) {
			col = 5;
		}
		else if (width > 250) {
			col = 4;
		}
		else if (width > 200) {
			col = 3;
		}
		else if (width > 150) {
			col = 2;
		}
		else if (width > 100) {
			col = 1;
		}
		else {
			col = 0;
		}
		total = modelsTable[dimention][row][col];
		return total;
	}

	function findPriceShirokoploshten(height, width) {
		let row = 0;
		let col = 0;
		let total = 0;
		let dimention = findTable(modelCode, colorCode);
		//-------- Width Parameters
		if (width < 100) {
			throwMinLenghtExeption(100);
		}

		if (width > 350) {
			throwMaxLenghtExeption(0, 350);
			return 1;
		}


		if (width > 350) {
			col = 6;
		}
		else if (width > 300) {
			col = 5;
		}
		else if (width > 250) {
			col = 4;
		}
		else if (width > 200) {
			col = 3;
		}
		else if (width > 150) {
			col = 2;
		}
		else if (width > 100) {
			col = 1;
		}
		else {
			col = 0;
		}
		//------- Lenght/Height Parameters
		if (height > 350) {
			throwMaxLenghtExeption(1, 350);
			return 1;
		}
		else if (height > 350) {
			row = 5;
		}
		else if (height > 300) {
			row = 5;
		}
		else if (height > 250) {
			row = 4;
		}
		else if (height > 200) {
			row = 3;
		}
		else if (height > 150) {
			row = 2;
		}
		else if (height > 100) {
			row = 1;
		}
		else {
			row = 0;
		}

		total = modelsTable[dimention][row][col];
		return total;
	}

	function findPriceCristal(height, width) {
		var row = 0;
		var col = 0;
		var total = 0;
		var dimention = findTable(modelCode, colorCode);
		//-------- Width Parameters
		if (width < 70) {
			throwMinLenghtExeption(70);
		}

		if (width > 350) {
			throwMaxLenghtExeption(0, 350);
			return 1;
		}
		if (width > 300) {
			col = 5;
		}
		else if (width > 250) {
			col = 4;
		}
		else if (width > 200) {
			col = 3;
		}
		else if (width > 150) {
			col = 2;
		}
		else if (width > 100) {
			col = 1;
		}
		else {
			col = 0;
		}
		//------- Lenght/Height Parameters

		if (height > 300) {
			throwMaxLenghtExeption(1, 300);
			return 1;
		}
		else if (height > 250) {
			row = 3;
		}
		else if (height > 200) {
			row = 2;
		}
		else if (height > 150) {
			row = 1;
		}
		else {
			row = 0;
		}

		total = modelsTable[dimention][row][col];
		return total;
	}

	function checkBreakingSholder(model, width, height) {
		let errMSG = "Минимална ширина на сенника = дължина на рамо + 35 см.";
		let errMSG2 = "При рамо 200, 250 или 300 см (за сенник 'Вера') минималната ширина на сенника = дължина на рамо + 60 см."
		if (model == 2) {
			if (height <= 50) {
				if (width < height + 35) {
					return errMSG;
				}
			}
			else {
				if (width < height + 60) {
					return errMSG2;
				}
			}
		}
		else {
			let minW = height + 35;
			if (width < minW) {
				return errMSG;
			}
		}
	}

	function printFinalPrice() {
		let error = undefined;

		let errMSG = "Зададените размери са извън позволената ширина/височина на продукта";
		let errMsgUnacceptable = "При зададените размери ширината и височината са несъвместими. Моля намалете височината.";
		let sizeWidth = Number(width);
		let sizeHeight = Number(height);
		let discount = 6;	//precent discount

		//CheckBoundories (modelCode, sizeWidth, sizeHeight);

		// Setting the prize for the Total
		switch (modelCode) {
			case 0:
			case 2:
				totalPrice = findPriceStandartAndVera(sizeHeight, sizeWidth);
				error = checkBreakingSholder(modelCode, sizeWidth, sizeHeight);
				break;

			case 1:
				totalPrice = findPriceElegans(sizeHeight, sizeWidth);
				error = checkBreakingSholder(modelCode, sizeWidth, sizeHeight);
				break;

			case 3:
				totalPrice = findPricePrestige(sizeHeight, sizeWidth);
				error = checkBreakingSholder(modelCode, sizeWidth, sizeHeight);
				break;

			case 4:
			case 5:
				totalPrice = findPriceClasicAndSmart(sizeHeight, sizeWidth);
				break;

			case 6:
				totalPrice = findPriceCabrio(sizeHeight, sizeWidth);
				break;

			case 7:
				totalPrice = findPriceBalkonski(sizeHeight, sizeWidth);
				break;

			case 8:
				totalPrice = findPriceCristal(sizeHeight, sizeWidth);
				break;

			case 9:
				totalPrice = findPriceShirokoploshten(sizeHeight, sizeWidth);
				break;
		}

		if (error !== undefined) {
			return error
		}

		if (isNaN(totalPrice)) {
			return totalPrice;
        }

		// TODO: If total = 0
		// TODO: If total = 1
		if (totalPrice == 0) {
			return errMsgUnacceptable;
		}
		else if (totalPrice == 1) {
			return errMSG;
		}
		else {
			return totalPrice - totalPrice * discount / 100;
		}
	}
}

export default {
    calculate,
}
