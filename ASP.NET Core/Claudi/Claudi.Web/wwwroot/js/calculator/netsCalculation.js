function calculate(model, color, width, height) {
	var colorCode = 0;	//default color
	var modelCode = 0; // default model
	var totalPrice = 0;

	// Prices by different models and colors
	var netsContent = ["Фиксиран Комарник", "Комарник на Панти", "Ролетен Комарник в рамка", "Ролетен Комарник с вграден водач", "Ролетен Хоризонтален Комарник", "Врата Мрежа"]

	var netsTable = [
		[],	// Static
		[],// hinges
		[],
		[],
		[],
		[]	// hinges door
	];

	var netsColors = ["Бял", "Кафяв", "Имитация на дърво", "Цвят по RAL"];

	var profile = [13.5, 13.5, 19.5, 19.5];	// Only Roller


	//panti
	var insectNetWithPanti = [
		[29, 29, 29, 29, 29, 29, 29, 29, 29, 31],
		[29, 29, 29, 29, 29, 29, 29, 30, 32, 34],
		[29, 29, 29, 29, 29, 29, 30, 32, 35, 37],
		[29, 29, 29, 29, 29, 31, 33, 35, 37, 40],
		[29, 29, 29, 29, 31, 33, 35, 38, 40, 42],
		[29, 29, 29, 31, 33, 35, 38, 40, 43, 45],
		[29, 29, 30, 33, 35, 38, 40, 43, 45, 48],
		[29, 30, 32, 35, 38, 40, 43, 45, 48, 51],
		[29, 32, 35, 37, 40, 43, 45, 48, 51, 53],
		[31, 34, 37, 40, 42, 45, 48, 51, 53, 56],
		[33, 36, 39, 42, 45, 47, 50, 53, 56, 59],
		[35, 38, 41, 44, 47, 50, 53, 56, 59, 62],
		[37, 40, 43, 46, 49, 52, 55, 58, 62, 65],
		[39, 42, 45, 48, 52, 55, 58, 61, 64, 67],
		[41, 44, 47, 51, 54, 57, 60, 64, 67, 70],
		[45, 49, 52, 55, 59, 62, 66, 69, 72, 76],
		[47, 51, 54, 58, 61, 65, 68, 71, 75, 78],
		[49, 53, 56, 60, 63, 67, 71, 74, 78, 81],
		[51, 55, 58, 62, 66, 69, 73, 77, 80, 84],
		[53, 57, 61, 64, 68, 72, 76, 79, 83, 87]
	];

	//fix
	var insectNetFix = [
		[23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 24, 25, 26, 28, 29],
		[23, 23, 23, 23, 23, 23, 23, 23, 23, 24, 25, 26, 27, 29, 30, 31],
		[23, 23, 23, 23, 23, 23, 23, 23, 24, 26, 27, 28, 30, 31, 32, 33],
		[23, 23, 23, 23, 23, 23, 23, 25, 26, 28, 29, 30, 32, 33, 34, 36],
		[23, 23, 23, 23, 23, 24, 25, 27, 28, 29, 31, 32, 34, 35, 37, 49],
		[23, 23, 23, 23, 24, 25, 27, 28, 30, 31, 33, 34, 36, 47, 49, 51],
		[23, 23, 23, 23, 25, 27, 28, 30, 32, 33, 35, 45, 47, 49, 51, 53],
		[23, 23, 23, 25, 27, 28, 30, 32, 33, 35, 44, 47, 49, 51, 54, 56],
		[23, 23, 24, 26, 28, 30, 32, 33, 42, 44, 46, 49, 51, 53, 56, 58],
		[23, 24, 26, 28, 29, 31, 33, 35, 43, 46, 48, 51, 53, 56, 58, 61],
		[23, 25, 27, 29, 31, 33, 35, 43, 45, 48, 50, 53, 55, 58, 60, 63],
		[24, 26, 28, 30, 32, 34, 42, 44, 47, 50, 52, 55, 57, 60, 63, 65],
		[25, 27, 30, 32, 34, 36, 43, 46, 49, 51, 54, 57, 60, 62, 65, 68],
		[26, 29, 31, 33, 35, 42, 45, 48, 51, 53, 56, 59, 62, 65, 67, 70],
		[28, 30, 32, 34, 37, 44, 47, 49, 52, 55, 58, 61, 64, 67, 70, 72],
		[29, 31, 33, 36, 42, 45, 48, 51, 54, 57, 60, 63, 66, 69, 72, 75],
		[30, 32, 35, 37, 44, 47, 50, 53, 56, 59, 62, 65, 68, 71, 74, 77],
		[31, 34, 36, 39, 45, 48, 51, 55, 58, 61, 64, 67, 70, 73, 76, 80],
		[32, 35, 37, 43, 47, 50, 53, 56, 60, 63, 66, 69, 72, 76, 79, 82],
		[33, 36, 39, 45, 48, 51, 55, 58, 61, 65, 68, 71, 75, 78, 81, 84]
	];

	//vrati
	var doorInsectNet = [
		[59, 59, 59, 59, 59, 59, 60, 63, 66],
		[59, 59, 59, 59, 59, 61, 64, 66, 69],
		[59, 59, 59, 59, 61, 64, 67, 70, 72],
		[59, 59, 59, 61, 64, 67, 70, 73, 76],
		[59, 59, 61, 64, 67, 70, 73, 76, 79],
		[59, 61, 64, 67, 70, 73, 76, 80, 83],
		[60, 64, 67, 70, 73, 76, 80, 83, 86],
		[63, 66, 70, 73, 76, 80, 83, 98, 103],
		[66, 69, 72, 76, 79, 83, 86, 102, 106],
		[68, 72, 75, 79, 82, 86, 100, 105, 109],
		[71, 74, 78, 82, 85, 99, 103, 108, 113],
		[73, 77, 81, 84, 88, 102, 107, 111, 116],
		[76, 80, 83, 87, 100, 105, 110, 115, 120],
		[78, 82, 86, 90, 103, 108, 113, 118, 123],
		[81, 85, 89, 101, 106, 111, 116, 121, 127],
		[83, 87, 92, 104, 109, 114, 119, 125, 130],
		[86, 90, 94, 106, 112, 117, 123, 128, 133],
		[88, 93, 104, 109, 115, 120, 126, 131, 137],
		[91, 95, 106, 112, 118, 123, 129, 135, 140],
		[93, 98, 109, 115, 121, 126, 132, 138, 144],
		[96, 101, 112, 118, 124, 130, 135, 141, 147],
		[98, 109, 115, 121, 127, 133, 139, 145, 151]
	];

	//ramka 20/40
	var insectNetInFrame = [
		[65, 65, 65, 65, 69, 75, 80, 86, 91, 96, 102, 107],
		[65, 65, 65, 67, 72, 78, 83, 89, 94, 100, 106, 111],
		[65, 65, 65, 70, 75, 81, 87, 92, 98, 104, 109, 115],
		[65, 65, 67, 73, 79, 84, 90, 96, 101, 107, 113, 118],
		[65, 65, 70, 76, 82, 87, 93, 99, 105, 111, 116, 122],
		[65, 67, 73, 79, 85, 91, 96, 102, 108, 114, 120, 126],
		[65, 70, 76, 82, 88, 94, 100, 106, 112, 118, 124, 130],
		[67, 73, 79, 85, 91, 97, 103, 109, 115, 121, 127, 133],
		[69, 75, 82, 88, 94, 100, 106, 112, 119, 125, 131, 137],
		[72, 78, 84, 91, 97, 103, 109, 116, 122, 128, 135, 141],
		[75, 81, 87, 94, 100, 106, 113, 119, 125, 132, 138, 144],
		[77, 84, 90, 97, 103, 110, 116, 122, 129, 135, 142, 148],
		[83, 91, 98, 105, 113, 120, 127, 135, 142, 149, 157, 164],
		[86, 93, 101, 108, 116, 123, 131, 138, 145, 153, 160, 168],
		[89, 96, 104, 111, 119, 126, 134, 141, 149, 156, 164, 171],
		[91, 99, 107, 114, 122, 129, 137, 145, 152, 160, 167, 175],
		[94, 102, 110, 117, 125, 133, 140, 148, 156, 163, 171, 179],
		[97, 105, 112, 120, 128, 136, 144, 151, 159, 167, 175, 183],
		[100, 108, 115, 123, 131, 139, 147, 154, 162, 170, 178, 185],
		[103, 111, 118, 126, 134, 142, 150, 157, 165, 173, 181, 188]
	];

	//vgraden vodach
	var insectNetWithBuiltInDriver = [
		[79, 79, 83, 89, 96, 103, 110, 116, 123, 130, 136, 143],
		[79, 81, 88, 95, 102, 108, 115, 122, 129, 136, 142, 149],
		[79, 86, 93, 100, 107, 114, 121, 128, 135, 141, 148, 155],
		[84, 91, 98, 105, 112, 119, 126, 133, 140, 147, 154, 161],
		[89, 96, 103, 111, 118, 125, 132, 139, 146, 153, 160, 167],
		[94, 101, 109, 116, 123, 130, 137, 145, 152, 159, 166, 173],
		[99, 106, 114, 121, 128, 136, 143, 150, 158, 165, 172, 180],
		[104, 112, 119, 126, 134, 141, 149, 156, 163, 171, 178, 186],
		[109, 117, 124, 132, 139, 147, 154, 162, 169, 177, 184, 192],
		[114, 122, 129, 137, 145, 152, 160, 167, 175, 183, 190, 198],
		[119, 127, 135, 142, 150, 158, 165, 173, 181, 188, 196, 204],
		[124, 132, 140, 148, 155, 163, 171, 179, 187, 194, 202, 210],
		[132, 141, 149, 158, 166, 175, 183, 192, 201, 209, 218, 226],
		[137, 146, 154, 163, 172, 180, 189, 198, 206, 215, 224, 233],
		[142, 151, 159, 168, 177, 186, 195, 203, 212, 221, 230, 239],
		[147, 156, 165, 174, 182, 191, 200, 209, 218, 227, 236, 245],
		[152, 161, 170, 179, 188, 197, 206, 215, 224, 233, 242, 251],
		[157, 166, 175, 184, 193, 202, 211, 220, 230, 239, 248, 257],
		[160, 169, 178, 187, 196, 205, 214, 223, 233, 242, 251, 260],
		[163, 172, 181, 190, 199, 208, 217, 226, 236, 245, 254, 263]
	];

	//horizontalen
	var insectNetHorizontal = [
		[87, 90, 93, 96, 99, 102, 105, 108, 111, 114, 117, 120, 123],
		[96, 99, 102, 105, 108, 111, 114, 117, 120, 123, 127, 130, 133],
		[105, 108, 111, 114, 117, 121, 124, 127, 130, 133, 136, 139, 143],
		[114, 117, 120, 123, 127, 130, 133, 136, 140, 143, 146, 149, 153],
		[122, 126, 129, 132, 136, 139, 142, 146, 149, 152, 156, 159, 163],
		[131, 135, 138, 141, 145, 148, 152, 155, 159, 162, 166, 169, 172],
		[140, 143, 147, 151, 154, 158, 161, 165, 168, 172, 175, 179, 182],
		[149, 152, 156, 160, 163, 167, 171, 174, 178, 181, 185, 189, 192],
		[158, 161, 165, 169, 172, 176, 180, 184, 187, 191, 195, 199, 202],
		[166, 170, 174, 178, 182, 185, 189, 193, 197, 201, 205, 208, 212],
		[175, 179, 183, 187, 191, 195, 199, 203, 207, 210, 214, 218, 222],
		[184, 188, 192, 196, 200, 204, 208, 212, 216, 220, 224, 228, 232],
		[195, 197, 201, 205, 209, 213, 217, 221, 225, 229, 233, 237, 241],
		[204, 206, 210, 214, 218, 222, 226, 230, 234, 238, 242, 246, 250],
		[213, 215, 219, 223, 227, 231, 235, 239, 243, 247, 251, 255, 259],
		[222, 224, 228, 232, 236, 240, 244, 248, 252, 256, 260, 264, 268],
		[231, 233, 237, 241, 245, 249, 253, 257, 261, 265, 269, 273, 277],
		[240, 242, 246, 250, 254, 258, 262, 266, 270, 274, 278, 282, 286],
		[249, 253, 255, 259, 263, 267, 271, 275, 279, 283, 287, 291, 295],
		[258, 262, 264, 268, 272, 276, 280, 284, 288, 292, 296, 300, 304]
	];

	getColor();
	getModel();
	let error = checkBoundories(modelCode, width, height);
	return printFinalPrice(error);

	function getColor() {
		colorCode = netsColors.indexOf(color);
	}

	function getModel() {
		modelCode = netsContent.indexOf(model);
	}

	function checkBoundories(model, width, height) {
		var sqrtM = width * height / 10000;
		var isThereError = false;
		var errorMSG = "Зададените размери са извън позволената ширина/височина на продукта";

		if (sqrtM > 3.84) {
			return "Зададените размери са извън позволената площ на продукта";
		}

		switch (model) {
			case 0:	//static 
				if (width < 15 || width > 180 || height < 15 || height > 220) {
					isThereError = true;
				} break;
			case 1:	//static with hinges
				if (width < 15 || width > 120 || height < 15 || height > 220) {
					isThereError = true;
				} break;
			case 2:	//roller in frame
				if (width < 30 || width > 150 || height < 30 || height > 240) {
					isThereError = true;
				} break;
			case 3:	 //roller in-built driver
				if (width < 30 || width > 150 || height < 30 || height > 240) {
					isThereError = true;
				} break;

			case 4:	 //roller horizontal
				if (width < 30 || width > 160 || height < 30 || height > 240) {
					isThereError = true;
				} break;
			case 5:	// vrata
				if (width < 40 || width > 100 || height < 40 || height > 240) {
					isThereError = true;
				} break;
		}

		if (isThereError) {
			return errorMSG;

		}
	}

	function ConvertInsectNetWidth(arg) {
		var local = Math.round(Math.ceil(arg) / 10);

		local = local - 4;

		if (local < 0) {
			local = 0;
		}

		return local;
	}

	function ConvertInsectNetHeigth(arg) {
		var local = Math.round(Math.ceil(arg) / 10);

		local = local - 5;

		if (local < 0) {
			local = 0;
		}

		return local;
	}

	function ConvertInsectNetPantiAndFix(arg) {
		var local = Math.round(Math.ceil(arg) / 10);

		local = local - 3;

		if (local < 0) {
			local = 0;
		}

		return local;
	}

	function ConvertInsectNetDoor(arg) {
		var local = Math.round(Math.ceil(arg) / 10);

		local = local - 4;

		if (local < 0) {
			local = 0;
		}

		return local;
	}

	//Calc the final price
	function printFinalPrice(error) {
		if (error !== undefined) {
			return error;
		}

		let convertedWidth = undefined;
		let convertedHeight = undefined;
		var sizeWidth = width;
		var sizeHeight = height;
		var squareMeters;
		var pricePerSquareMeter = 0;
		var linearMeters = 0;
		var discount = 6;	//percent discount

		squareMeters = sizeWidth * sizeHeight / 10000;
		if (squareMeters < 0.5) {
			squareMeters = 0.5;
		}

		if (modelCode > 1 && modelCode < 5) {

			convertedWidth = ConvertInsectNetWidth(sizeWidth);
			convertedHeight = ConvertInsectNetHeigth(sizeHeight);

			switch (modelCode) {
				case 2:
					totalPrice = insectNetInFrame[convertedHeight][convertedWidth];
					break;
				case 3:
					totalPrice = insectNetWithBuiltInDriver[convertedHeight][convertedWidth];
					break;
				case 4:
					totalPrice = insectNetHorizontal[convertedHeight][convertedWidth];
					break;
			}

			if (modelCode == 2 || modelCode == 3 || modelCode == 4) {
				if (colorCode == 2 || colorCode == 3) {
					totalPrice = totalPrice * 1.25;
				}

			}

			linearMeters += (sizeWidth / 100);
			linearMeters += (sizeHeight / 100);
			linearMeters = linearMeters * 2;

			if (modelCode == 2 || modelCode == 4) {
				totalPrice = totalPrice + (linearMeters * profile[colorCode]);
			}

		}
		else if (modelCode == 0 || modelCode == 1) {

			convertedWidth = ConvertInsectNetPantiAndFix(sizeWidth);
			convertedHeight = ConvertInsectNetPantiAndFix(sizeHeight);

			switch (modelCode) {
				case 0:
					totalPrice = insectNetFix[convertedHeight][convertedWidth];
					break;
				case 1:
					totalPrice = insectNetWithPanti[convertedHeight][convertedWidth];
					break;
			}

			if (colorCode == 2) {
				if (modelCode === 0) {
					totalPrice = totalPrice * 1.1;
				}
				else {
					totalPrice = totalPrice * 1.3;
				}
			}
			else if (colorCode == 3) {
				totalPrice = totalPrice * 1.3;
			}
		}
		else if (modelCode == 5) {

			convertedWidth = ConvertInsectNetDoor(sizeWidth);
			convertedHeight = ConvertInsectNetDoor(sizeHeight);

			totalPrice = doorInsectNet[convertedHeight][convertedWidth];

			if (colorCode == 2 || colorCode == 3) {
				totalPrice = totalPrice * 1.1;
			}

		}
		totalPrice -= totalPrice * (discount / 100);

		return totalPrice;
	}
}

export default {
    calculate,
}
