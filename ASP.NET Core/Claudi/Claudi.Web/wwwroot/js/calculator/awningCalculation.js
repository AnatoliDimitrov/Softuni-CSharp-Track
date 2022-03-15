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
				[971, 1107, 1171, 1236, 1372, 1438, 1646, 1902, 2046, 2253, 2320],
				[0, 1202, 1268, 1336, 1488, 1556, 1781, 2054, 2200, 2425, 2491],
				[0, 0, 1375, 1443, 1614, 1682, 1924, 2220, 2369, 2612, 2679],
				[0, 0, 0, 1583, 1771, 1912, 2101, 2169, 2591, 2780, 2848],
				[0, 0, 0, 0, 2039, 2109, 2316, 2385, 2536, 3071, 0],
				[0, 0, 0, 0, 0, 2214, 2583, 2654, 2806, 0, 0]
			],
			[                   //4
				[1019, 1168, 1236, 1303, 1452, 1520, 1744, 2005, 2156, 2379, 2447],
				[0, 1273, 1343, 1411, 1580, 1649, 1893, 2174, 2324, 2568, 2637],
				[0, 0, 1457, 1528, 1718, 1788, 2051, 2356, 2509, 2774, 2842],
				[0, 0, 0, 1678, 1889, 2033, 2244, 2316, 2749, 2960, 3031],
				[0, 0, 0, 0, 2173, 2245, 2475, 2547, 2703, 3274, 0],
				[0, 0, 0, 0, 0, 2362, 2762, 2835, 2993, 0, 0]
			],
			[                   //5
				[1088, 1263, 1332, 1400, 1575, 1643, 1894, 2164, 2318, 2569, 2639],
				[0, 1385, 1456, 1526, 1726, 1796, 2072, 2360, 2515, 2792, 2862],
				[0, 0, 1588, 1660, 1885, 1957, 2258, 2572, 2729, 3030, 3101],
				[0, 0, 0, 1829, 2079, 2230, 2479, 2551, 3000, 3249, 3323],
				[0, 0, 0, 0, 2389, 2465, 2740, 2815, 2974, 3599, 0],
				[0, 0, 0, 0, 0, 2604, 3058, 3134, 3294, 0, 0]
			],
			[
				//Vera          //6
				[1217, 1400, 1520, 1641, 1823, 1944, 2255],
				[0, 0, 1644, 1766, 1964, 2085, 2411],
				[0, 0, 0, 1893, 2106, 2229, 2570],
				[0, 0, 0, 0, 2247, 2370, 2727]
			],
			[                   //7
				[1297, 1497, 1623, 1751, 1950, 2077, 2414],
				[0, 0, 1760, 1887, 2105, 2232, 2588],
				[0, 0, 0, 2028, 2263, 2393, 2765],
				[0, 0, 0, 0, 2418, 2549, 2937]
			],
			[                 //8
				[1371, 1594, 1725, 1855, 2080, 2209, 2573],
				[0, 0, 1877, 2008, 2255, 2387, 2773],
				[0, 0, 0, 2165, 2435, 2567, 2976],
				[0, 0, 0, 0, 2610, 2743, 3176]
			],
			[
				//Prestige   //9
				[1526, 1730, 1877, 2021, 2229, 2373, 2579, 3145, 3368, 3574, 3719],
				[0, 1832, 1978, 2124, 2346, 2492, 2713, 3303, 3527, 3750, 3896],
				[0, 0, 2084, 2231, 2469, 2616, 2853, 3472, 3700, 3936, 4145],
				[0, 0, 0, 2334, 2585, 2797, 3048, 3198, 3923, 4173, 0]
			],
			[               //10
				[1620, 1846, 1998, 2151, 2376, 2528, 2754, 3349, 3584, 3809, 3961],
				[0, 1957, 2110, 2263, 2507, 2661, 2905, 3525, 3761, 4005, 4158],
				[0, 0, 2229, 2383, 2645, 2799, 3061, 3713, 3951, 4213, 4433],
				[0, 0, 0, 2496, 2775, 2998, 3277, 3433, 4195, 4474, 0]
			],
			[               //11
				[1689, 1937, 2092, 2248, 2494, 2649, 2897, 3504, 3744, 3991, 4147],
				[0, 2062, 2217, 2375, 2645, 2800, 3072, 3704, 3945, 4215, 4372],
				[0, 0, 2351, 2508, 2800, 2958, 3252, 3916, 4158, 4450, 4676],
				[0, 0, 0, 2636, 2951, 3176, 3491, 3652, 4426, 4743, 0]
			],
			[
				//Classic   //12
				[627, 709, 745, 826, 863, 900, 981],
				[653, 750, 789, 886, 922, 961, 1058],
				[681, 794, 833, 946, 986, 1026, 1138],
				[712, 840, 882, 1010, 1052, 1094, 1221],
				[738, 881, 925, 1068, 1112, 1157, 1299]
			],
			[                //13
				[633, 721, 757, 845, 880, 917, 1004],
				[661, 766, 804, 908, 946, 984, 1089],
				[690, 814, 853, 974, 1015, 1054, 1177],
				[723, 863, 904, 1044, 1086, 1127, 1266],
				[751, 906, 951, 1107, 1151, 1194, 1351]
			],
			[               //14
				[678, 782, 821, 925, 963, 1001, 1106],
				[710, 836, 877, 1002, 1042, 1083, 1209],
				[746, 894, 936, 1085, 1126, 1168, 1316],
				[784, 953, 998, 1167, 1212, 1256, 1426],
				[817, 1008, 1054, 1245, 1292, 1338, 1529]
			],
			[
				//Smart    //15
				[693, 854, 970, 1134, 1248, 1364, 1527],
				[718, 897, 1015, 1193, 1311, 1429, 1607],
				[747, 943, 1063, 1257, 1377, 1497, 1692],
				[780, 991, 1113, 1323, 1446, 1568, 1777],
				[807, 1034, 1158, 1384, 1508, 1632, 1860]
			],
			[               //16
				[698, 867, 983, 1151, 1266, 1383, 1552],
				[726, 913, 1030, 1217, 1335, 1453, 1640],
				[758, 962, 1082, 1287, 1407, 1526, 1730],
				[792, 1015, 1136, 1359, 1480, 1602, 1824],
				[821, 1061, 1184, 1425, 1549, 1672, 1913]
			],
			[               //17
				[725, 911, 1028, 1214, 1332, 1449, 1634],
				[757, 965, 1085, 1292, 1412, 1532, 1740],
				[793, 1022, 1144, 1374, 1496, 1618, 1847],
				[832, 1083, 1208, 1458, 1583, 1706, 1959],
				[865, 1138, 1264, 1537, 1664, 1791, 2063]
			],
			[
				//Kabrio   //18
				[506, 614, 682, 767, 874, 944, 1066, 1135],
				[732, 804, 941, 1028, 1165, 1237, 1323, 1461],
				[1014, 1087, 1255, 1343, 1417, 1585, 1674, 0],
				[1351, 1426, 1502, 1716, 1791, 1990, 0, 0]
			],
			[             //19
				[506, 614, 682, 767, 874, 944, 1066, 1135],
				[732, 804, 941, 1028, 1165, 1237, 1323, 1461],
				[1014, 1087, 1255, 1343, 1417, 1585, 1674, 0],
				[1351, 1426, 1502, 1716, 1791, 1990, 0, 0]
			],
			[             //20
				[551, 673, 746, 833, 956, 1029, 1167, 1240],
				[818, 893, 1054, 1144, 1306, 1381, 1472, 1632],
				[1158, 1234, 1434, 1528, 1605, 1805, 1897, 0],
				[1569, 1649, 1728, 1983, 2063, 2301, 0, 0]
			],
			[
				//Balkonski //21
				[394, 506, 542, 654, 689, 727, 839, 874, 1057, 1093, 1129]
			],
			[             //22
				[425, 553, 590, 719, 756, 794, 921, 960, 1161, 1199, 1237]
			],
			[             //23
				[468, 624, 663, 819, 858, 898, 1054, 1094, 1328, 1367, 1408]
			],
			[
				//Kristal // 24
				[267, 342, 416, 490, 564, 639],
				[288, 374, 460, 547, 632, 718],
				[309, 407, 505, 602, 700, 797],
				[331, 439, 549, 657, 767, 876]
			],
			[
				//Kristal Rido  //25
				[547, 677, 807, 939, 1069, 1199],
				[661, 803, 945, 1088, 1230, 1372],
				[775, 929, 1083, 1237, 1390, 1545],
				[890, 1056, 1220, 1386, 1552, 1717],
				[1004, 1181, 1358, 1535, 1713, 1889],
				[1118, 1307, 1496, 1684, 1873, 2062]
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
		if (height < 150 || height > 300) {
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
			if (height <= 150) {
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
