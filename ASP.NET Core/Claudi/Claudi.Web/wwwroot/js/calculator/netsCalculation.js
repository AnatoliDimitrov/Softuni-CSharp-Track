function calculate(model, color, width, height) {
	var colorCode = 0;	//default color
	var modelCode = 0; // default model
	var totalPrice = 0;

	// Prices by different models and colors
	var netsContent = ["Комарник на Панти", "Фиксиран Комарник", "Ролетен Комарник в рамка", "Ролетен Комарник с вграден водач", "Ролетен Хоризонтален Комарник", "Врата Мрежа"]

	var netsTable = [
		[],	// Static
		[],// hinges
		[],
		[],
		[],
		[]	// hinges door
	];

	var netsColors = ["Бял", "Кафяв", "Имитация на дърво", "Цвят по RAL"];

	var profile = [9.9, 9.9, 12.9, 12.9];	// Only Roller


	//panti
	var insectNetWithPanti = [
		[23, 23, 23, 23, 23, 23, 23, 25, 26, 28],
		[23, 23, 23, 23, 23, 23, 26, 27, 28, 31],
		[23, 23, 23, 23, 23, 26, 27, 30, 31, 33],
		[23, 23, 23, 25, 26, 28, 30, 32, 33, 37],
		[23, 23, 23, 26, 28, 30, 32, 36, 37, 39],
		[23, 23, 26, 28, 30, 32, 36, 37, 39, 42],
		[23, 26, 27, 30, 32, 36, 38, 39, 42, 44],
		[25, 27, 30, 32, 36, 37, 39, 42, 44, 48],
		[26, 28, 31, 33, 37, 39, 42, 44, 48, 50],
		[28, 31, 33, 37, 39, 42, 44, 48, 50, 53],
		[30, 32, 36, 38, 41, 44, 48, 50, 53, 55],
		[31, 36, 38, 41, 43, 46, 49, 53, 55, 58],
		[33, 37, 39, 42, 46, 49, 52, 55, 58, 60],
		[36, 38, 42, 44, 48, 52, 54, 57, 60, 64],
		[37, 41, 43, 48, 50, 53, 57, 59, 64, 66],
		[39, 42, 46, 49, 53, 55, 59, 63, 66, 69],
		[41, 43, 48, 52, 54, 58, 60, 65, 69, 71],
		[42, 46, 50, 53, 57, 59, 64, 68, 70, 75],
		[43, 48, 52, 55, 58, 63, 66, 70, 73, 77],
		[46, 50, 53, 57, 60, 65, 69, 73, 76, 80],
	];

	//fix
	var insectNetFix = [
		[23, 23, 23, 23, 23, 23, 23, 23, 23, 24, 27, 29, 30, 31, 33, 34],
		[23, 23, 23, 23, 23, 23, 23, 24, 25, 27, 29, 30, 33, 34, 35, 36],
		[23, 23, 23, 23, 23, 23, 24, 25, 29, 30, 31, 33, 35, 36, 37, 39],
		[23, 23, 23, 23, 23, 24, 27, 29, 30, 33, 34, 35, 37, 39, 41, 42],
		[23, 23, 23, 23, 24, 27, 29, 31, 33, 34, 36, 37, 39, 42, 43, 59],
		[23, 23, 23, 24, 27, 29, 31, 33, 35, 36, 39, 41, 42, 57, 59, 63],
		[23, 23, 24, 27, 29, 31, 33, 35, 36, 39, 41, 54, 57, 59, 63, 66],
		[23, 24, 25, 29, 31, 33, 35, 36, 39, 42, 54, 57, 59, 63, 66, 69],
		[23, 25, 29, 30, 33, 35, 36, 39, 49, 53, 57, 59, 63, 65, 69, 71],
		[24, 27, 30, 33, 34, 36, 39, 42, 53, 55, 58, 63, 65, 67, 71, 75],
		[27, 29, 31, 34, 36, 39, 41, 52, 54, 58, 60, 65, 67, 70, 75, 77],
		[29, 30, 33, 35, 37, 41, 49, 54, 57, 60, 64, 66, 70, 72, 77, 80],
		[30, 33, 35, 37, 39, 42, 53, 55, 59, 63, 66, 69, 72, 76, 80, 82],
		[31, 34, 36, 39, 42, 52, 54, 58, 60, 65, 69, 71, 76, 78, 82, 87],
		[33, 35, 37, 41, 43, 53, 57, 59, 64, 67, 70, 75, 78, 81, 86, 89],
		[34, 36, 39, 42, 52, 54, 58, 63, 66, 69, 72, 77, 81, 83, 88, 92],
		[35, 37, 41, 45, 53, 57, 60, 65, 67, 71, 76, 80, 83, 87, 90, 94],
		[36, 39, 43, 46, 54, 58, 63, 66, 70, 75, 78, 82, 87, 90, 93, 98],
		[37, 42, 45, 53, 57, 60, 65, 69, 72, 77, 81, 86, 89, 93, 96, 100],
		[39, 43, 46, 54, 58, 63, 66, 70, 75, 78, 82, 87, 90, 96, 100, 104]
	];

	//vrati
	var doorInsectNet = [
		[55, 58, 60, 64, 67, 70, 72, 76, 78],
		[58, 60, 65, 67, 70, 72, 77, 80, 82],
		[60, 65, 67, 70, 75, 77, 80, 83, 87],
		[64, 67, 70, 75, 77, 81, 83, 88, 90],
		[67, 70, 75, 77, 81, 83, 88, 90, 94],
		[70, 72, 77, 81, 83, 88, 90, 94, 99],
		[72, 77, 80, 83, 88, 90, 94, 99, 102],
		[76, 80, 83, 88, 90, 94, 99, 117, 123],
		[78, 82, 87, 90, 94, 99, 102, 122, 127],
		[81, 86, 89, 93, 98, 101, 121, 125, 131],
		[86, 89, 93, 98, 101, 119, 124, 130, 135],
		[88, 92, 96, 100, 104, 122, 127, 134, 139],
		[90, 94, 99, 104, 121, 125, 131, 136, 143],
		[93, 98, 102, 106, 123, 128, 135, 140, 147],
		[96, 101, 105, 121, 127, 133, 139, 145, 151],
		[99, 104, 110, 124, 130, 136, 142, 148, 154],
		[102, 106, 112, 127, 134, 139, 146, 153, 158],
		[105, 111, 124, 130, 136, 143, 149, 155, 161],
		[108, 113, 127, 134, 140, 147, 153, 159, 166],
		[111, 116, 130, 136, 143, 149, 157, 164, 170],
		[113, 119, 134, 140, 147, 154, 160, 167, 174],
		[116, 130, 136, 143, 149, 157, 165, 171, 178]
	];

	//ramka 20/40
	var insectNetInFrame = [
		[50, 55, 61, 66, 72, 78, 84, 89, 94, 100, 105, 111],
		[53, 58, 63, 69, 76, 81, 86, 91, 98, 103, 108, 115],
		[55, 61, 66, 72, 78, 84, 89, 94, 102, 107, 112, 117],
		[58, 63, 69, 76, 81, 86, 91, 99, 104, 109, 115, 121],
		[61, 66, 72, 78, 84, 89, 95, 102, 107, 113, 118, 125],
		[62, 69, 75, 81, 86, 91, 99, 104, 111, 116, 122, 129],
		[64, 72, 77, 84, 89, 95, 102, 108, 113, 120, 126, 132],
		[67, 75, 80, 86, 91, 99, 104, 111, 116, 122, 130, 135],
		[71, 76, 82, 89, 94, 102, 108, 113, 120, 126, 132, 139],
		[73, 78, 85, 91, 98, 104, 111, 117, 122, 130, 136, 142],
		[76, 81, 88, 94, 102, 107, 113, 120, 127, 132, 139, 145],
		[77, 84, 90, 98, 104, 111, 116, 122, 130, 136, 143, 148],
		[82, 89, 95, 104, 111, 117, 126, 132, 139, 145, 154, 161],
		[85, 91, 99, 107, 113, 120, 129, 135, 143, 149, 157, 165],
		[86, 94, 102, 109, 116, 125, 131, 138, 145, 153, 161, 167],
		[89, 98, 104, 112, 118, 127, 134, 142, 148, 157, 163, 171],
		[91, 100, 107, 115, 121, 130, 138, 144, 153, 159, 167, 174],
		[94, 103, 109, 117, 125, 132, 140, 147, 156, 163, 170, 179],
		[98, 106, 112, 119, 128, 135, 143, 151, 159, 166, 173, 182],
		[101, 109, 115, 121, 132, 138, 146, 154, 162, 169, 176, 185]
	];

	//vgraden vodach
	var insectNetWithBuiltInDriver = [
		[63, 71, 76, 81, 86, 91, 99, 104, 109, 115, 120, 126],
		[69, 75, 80, 85, 91, 98, 103, 108, 115, 120, 126, 132],
		[73, 78, 84, 90, 95, 102, 108, 113, 120, 126, 131, 138],
		[77, 82, 89, 94, 102, 107, 112, 118, 125, 131, 136, 143],
		[81, 88, 93, 100, 105, 112, 117, 125, 130, 136, 142, 148],
		[85, 91, 98, 104, 111, 116, 122, 129, 135, 140, 147, 154],
		[90, 95, 103, 108, 115, 121, 127, 134, 140, 145, 153, 159],
		[94, 100, 107, 113, 120, 126, 132, 139, 145, 152, 158, 165],
		[99, 105, 112, 117, 125, 131, 138, 144, 149, 157, 163, 170],
		[103, 109, 116, 122, 130, 135, 142, 148, 156, 162, 169, 175],
		[107, 113, 120, 127, 134, 140, 147, 154, 161, 167, 174, 181],
		[111, 118, 126, 132, 139, 145, 153, 159, 166, 172, 180, 186],
		[117, 126, 132, 140, 147, 156, 162, 170, 176, 185, 192, 199],
		[121, 130, 138, 144, 153, 159, 167, 175, 183, 190, 197, 206],
		[127, 134, 142, 149, 157, 165, 172, 180, 188, 196, 202, 211],
		[131, 139, 145, 154, 162, 170, 176, 185, 193, 201, 208, 216],
		[135, 143, 152, 159, 166, 174, 183, 190, 198, 206, 213, 221],
		[139, 147, 156, 163, 171, 180, 188, 196, 202, 211, 219, 226],
		[143, 152, 160, 167, 175, 184, 192, 200, 207, 215, 223, 230],
		[147, 156, 164, 171, 180, 188, 196, 204, 211, 219, 227, 235]
	];

	//horizontalen
	var insectNetHorizontal = [
		[71, 73, 76, 78, 81, 84, 86, 89, 91, 94, 98, 100, 103],
		[78, 82, 85, 88, 90, 93, 95, 99, 102, 104, 107, 109, 112],
		[88, 90, 93, 95, 99, 102, 104, 107, 109, 113, 116, 118, 121],
		[95, 99, 102, 104, 107, 109, 113, 116, 118, 121, 125, 129, 131],
		[104, 107, 109, 112, 116, 118, 121, 125, 129, 131, 134, 136, 140],
		[112, 115, 117, 121, 125, 127, 131, 134, 136, 140, 143, 145, 149],
		[120, 122, 127, 130, 132, 136, 139, 143, 145, 148, 153, 156, 159],
		[129, 131, 135, 138, 142, 144, 148, 152, 156, 158, 162, 165, 169],
		[136, 139, 143, 147, 149, 154, 157, 161, 163, 167, 170, 174, 179],
		[144, 148, 152, 156, 158, 162, 166, 169, 172, 176, 180, 184, 186],
		[153, 157, 159, 163, 167, 170, 174, 179, 183, 185, 189, 193, 196],
		[161, 165, 169, 171, 175, 180, 184, 186, 190, 194, 198, 202, 206],
		[169, 173, 177, 180, 184, 188, 192, 194, 198, 202, 207, 211, 214],
		[177, 182, 186, 188, 192, 196, 200, 202, 207, 211, 215, 219, 222],
		[186, 190, 194, 196, 200, 204, 209, 211, 215, 219, 223, 227, 234],
		[194, 198, 202, 204, 209, 213, 217, 219, 223, 227, 231, 236, 243],
		[198, 207, 211, 213, 217, 221, 225, 227, 231, 236, 240, 244, 252],
		[207, 215, 219, 221, 225, 229, 234, 236, 240, 244, 248, 252, 262],
		[215, 223, 227, 229, 234, 238, 242, 244, 248, 252, 256, 261, 271],
		[223, 231, 236, 238, 242, 246, 250, 252, 256, 261, 265, 269, 280]
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
			return error
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
