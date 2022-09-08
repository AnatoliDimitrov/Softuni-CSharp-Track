﻿function calculate(model, group, width, height, driving) {
	let colorCode = 0;	//default color
	let modelCode = 0; // default model
	let totalPrice = 0;

	let rollersModels = ["Стандарт", "Елеганс", "Комфорт"];
	let rollerTextiles = [
		"melisa",
		"classic",
		"carina",
		"luna",
		"classic bo",
		"lima",
		"lumina",
		"classic color bo",
		"melisa bo",
		"metalic",
		"lino",
		"tropic",
		"van gogh",
		"isabela bo",
		"juno",
		"glitter",
		"sierra color",
		"prato",
		"tundra",
		"corona bo",
		"lino bo",
		"green screen eco",
		"tendence bo",
		"valencia",
		"cotton flower",
		"monroe",
		"print",
	];

	let Coeficientrulo = [
		[1.00, 1.00, 1.10, 1.20, 1.20, 1.30, 1.30, 1.30, 1.30, 1.30, 1.30, 1.30, 1.40, 1.40, 1.50, 1.50, 1.50, 1.70, 1.80, 1.90, 2.00, 2.00, 2.00, 2.00, 2.20, 2.30, 2.50],	// Standart
		[1.00, 1.00, 1.10, 1.10, 1.20, 1.20, 1.20, 1.20, 1.20, 1.20, 1.30, 1.30, 1.30, 1.30, 1.30, 1.30, 1.30, 1.50, 1.50, 1.50, 1.50, 1.70, 1.70, 1.70, 1.80, 1.80, 1.90],	// Elegans
		[1.00, 1.00, 1.20, 1.20, 1.20, 1.20, 1.20, 1.20, 1.30, 1.30, 1.30, 1.30, 1.30, 1.30, 1.40, 1.40, 1.40, 1.40, 1.60, 1.60, 1.60, 1.80, 1.80, 1.50, 2.00, 2.00, 2.00]	// komfort
	];

	// Roller STANDART
	let rollerStandart = [
		[20, 20, 20, 20, 22, 24, 26, 28, 30, 33, 35, 37, 39, 41, 43],
		[20, 20, 20, 21, 24, 26, 28, 31, 33, 35, 38, 40, 42, 45, 47],
		[20, 20, 20, 23, 25, 28, 30, 33, 36, 38, 41, 43, 46, 48, 51],
		[20, 20, 22, 24, 27, 30, 33, 35, 38, 41, 44, 46, 49, 52, 55],
		[20, 20, 23, 26, 29, 32, 35, 38, 41, 44, 47, 49, 52, 55, 58],
		[20, 21, 24, 27, 31, 34, 37, 40, 43, 46, 49, 53, 56, 59, 62],
		[20, 22, 26, 29, 32, 36, 39, 42, 46, 49, 52, 56, 59, 62, 66],
		[20, 23, 27, 31, 34, 38, 41, 45, 48, 52, 55, 59, 62, 66, 70],
		[21, 25, 28, 32, 36, 40, 43, 47, 51, 55, 58, 62, 66, 70, 73],
		[22, 26, 30, 34, 38, 41, 45, 49, 53, 57, 61, 65, 69, 73, 77],
		[23, 27, 31, 35, 39, 43, 48, 52, 56, 60, 64, 68, 72, 77, 81],
		[24, 28, 32, 37, 41, 45, 50, 54, 58, 63, 67, 71, 76, 80, 85],
		[24, 29, 34, 38, 43, 47, 52, 56, 61, 66, 70, 75, 79, 84, 88],
		[25, 30, 35, 40, 44, 49, 54, 59, 63, 68, 73, 78, 83, 87, 92],
		[26, 31, 36, 41, 46, 51, 56, 61, 66, 71, 76, 81, 86, 91, 96],
		[27, 32, 38, 43, 48, 53, 58, 63, 69, 74, 79, 84, 89, 94, 100],
		[28, 34, 39, 44, 50, 55, 60, 66, 71, 76, 82, 87, 93, 98, 103],
		[29, 35, 40, 46, 51, 57, 63, 68, 74, 79, 85, 90, 96, 102, 107],
		[30, 36, 42, 47, 53, 59, 65, 70, 76, 82, 88, 94, 99, 105, 111],
		[31, 37, 43, 49, 55, 61, 67, 73, 79, 85, 91, 97, 103, 109, 115],
		[32, 38, 44, 50, 57, 63, 69, 75, 81, 87, 94, 100, 106, 112, 118],
		[33, 39, 46, 52, 58, 65, 71, 77, 84, 90, 97, 103, 109, 116, 122]
	];

	let rollerElegans = [
		[39, 39, 39, 40, 44, 48, 51, 55, 59, 63, 67, 70],
		[39, 39, 39, 43, 47, 51, 55, 59, 63, 67, 71, 75],
		[39, 39, 41, 46, 50, 54, 58, 63, 67, 71, 76, 80],
		[39, 39, 44, 48, 53, 57, 62, 66, 71, 75, 80, 85],
		[39, 42, 46, 51, 56, 61, 65, 70, 75, 80, 85, 89],
		[39, 44, 49, 54, 59, 64, 69, 74, 79, 84, 89, 94],
		[41, 46, 52, 57, 62, 67, 73, 78, 83, 88, 94, 99],
		[43, 49, 54, 60, 65, 71, 76, 82, 87, 93, 98, 104],
		[45, 51, 57, 62, 68, 74, 80, 85, 91, 97, 103, 108],
		[47, 53, 59, 65, 71, 77, 83, 89, 95, 101, 107, 113],
		[49, 56, 62, 68, 74, 80, 87, 93, 99, 105, 112, 118],
		[51, 58, 64, 71, 77, 84, 90, 97, 103, 110, 116, 122],
		[53, 60, 67, 74, 80, 87, 94, 100, 107, 114, 121, 127],
		[56, 62, 69, 76, 83, 90, 97, 104, 111, 118, 125, 132],
		[58, 65, 72, 79, 86, 94, 101, 108, 115, 122, 130, 137],
		[60, 67, 75, 82, 89, 97, 104, 112, 119, 127, 134, 141],
		[62, 69, 77, 85, 92, 100, 108, 115, 123, 131, 139, 146],
		[64, 72, 80, 88, 95, 103, 111, 119, 127, 135, 143, 151],
		[66, 74, 82, 90, 99, 107, 115, 123, 131, 139, 148, 156],
		[68, 76, 85, 93, 102, 110, 118, 127, 135, 144, 152, 160],
		[70, 79, 87, 96, 105, 113, 122, 131, 139, 148, 157, 165],
		[72, 81, 90, 99, 108, 117, 125, 134, 143, 152, 161, 170]
	];

	let rollerPrestige = [
		[45, 45, 45, 45, 48, 52, 55, 58, 62, 65, 69, 72, 75, 79, 82, 86, 89, 92, 96],
		[45, 45, 45, 46, 50, 54, 57, 61, 65, 68, 72, 75, 79, 83, 86, 90, 93, 97, 101],
		[45, 45, 45, 48, 52, 56, 60, 63, 67, 71, 75, 79, 83, 86, 90, 94, 98, 102, 106],
		[45, 45, 46, 50, 54, 58, 62, 66, 70, 74, 78, 82, 86, 90, 94, 99, 103, 107, 111],
		[45, 45, 47, 51, 56, 60, 64, 69, 73, 77, 81, 86, 90, 94, 99, 103, 107, 111, 116],
		[45, 45, 49, 53, 58, 62, 67, 71, 76, 80, 85, 89, 94, 98, 103, 107, 112, 116, 121],
		[45, 45, 50, 55, 59, 64, 69, 74, 78, 83, 88, 93, 97, 102, 107, 112, 116, 121, 126],
		[45, 46, 51, 56, 61, 66, 71, 76, 81, 86, 91, 96, 101, 106, 111, 116, 121, 126, 131],
		[45, 48, 53, 58, 63, 68, 74, 79, 84, 89, 94, 99, 105, 110, 115, 120, 125, 131, 136],
		[45, 49, 54, 60, 65, 70, 76, 81, 87, 92, 98, 103, 108, 114, 119, 125, 130, 135, 141],
		[45, 50, 56, 61, 67, 73, 78, 84, 89, 95, 101, 106, 112, 118, 123, 129, 134, 140, 146],
		[45, 51, 57, 63, 69, 75, 81, 86, 92, 98, 104, 110, 116, 121, 127, 133, 139, 145, 151],
		[46, 53, 59, 65, 71, 77, 83, 89, 95, 101, 107, 113, 119, 125, 131, 138, 144, 150, 156],
		[47, 54, 60, 66, 73, 79, 85, 92, 98, 104, 110, 117, 123, 129, 136, 142, 148, 154, 161],
		[48, 55, 61, 68, 75, 81, 88, 94, 101, 107, 114, 120, 127, 133, 140, 146, 153, 159, 166],
		[49, 56, 63, 70, 76, 83, 90, 97, 103, 110, 117, 124, 130, 137, 144, 151, 157, 164, 171],
		[50, 57, 64, 71, 78, 85, 92, 99, 106, 113, 120, 127, 134, 141, 148, 155, 162, 169, 176],
		[51, 59, 66, 73, 80, 87, 95, 102, 109, 116, 123, 130, 138, 145, 152, 159, 166, 174, 181],
		[52, 60, 67, 75, 82, 89, 97, 104, 112, 119, 126, 134, 141, 149, 156, 164, 171, 178, 186],
		[53, 61, 69, 76, 84, 92, 99, 107, 114, 122, 130, 137, 145, 153, 160, 168, 175, 183, 191],
		[54, 62, 70, 78, 86, 94, 102, 109, 117, 125, 133, 141, 149, 156, 164, 172, 180, 188, 196],
		[55, 64, 72, 80, 88, 96, 104, 112, 120, 128, 136, 144, 152, 160, 168, 177, 185, 193, 201],
		[56, 65, 73, 81, 90, 98, 106, 114, 123, 131, 139, 148, 156, 164, 173, 181, 189, 197, 206],
		[57, 66, 74, 83, 91, 100, 109, 117, 126, 134, 143, 151, 160, 168, 177, 185, 194, 202, 211],
		[58, 67, 76, 85, 93, 102, 111, 120, 128, 137, 146, 155, 163, 172, 181, 190, 198, 207, 216]
	];
	
	getColor();
	getModel();
	let error = CheckBoundories(modelCode, width, height);
	return printFinalPrice(error);

	//Receving Info from dropdown menu
	function getColor() {
		colorCode = rollerTextiles.indexOf(group);
	}

	function getModel() {
		modelCode = rollersModels.indexOf(model);
	}

	function findPrizerulo(arg) {
		let local = Math.round(Math.ceil(arg) / 10);
		local = local - 4;

		if (local < 0) {
			local = 0;
		}

		return local;
	}

	function CheckBoundories(model, width, height) {
		let errMSG = "Зададените размери са извън позволената ширина/височина на продукта";
		switch (model) {
			case 0:
				if (width > 180 || width < 15 || height > 250 || height < 15) {
					alert(errMSG);
				} break;

			case 1:
				if (width > 150 || width < 15 || height > 250 || height < 15) {
					alert(errMSG);
				} break;

			case 2:
				if (width > 220 || width < 40 || height > 300 || height < 40) {
					alert(errMSG);
				} break;
		}
	}

	function printFinalPrice(error) {
		if (error !== undefined) {
			return error
		}

		let discount = 6;	//precent discount

		width = findPrizerulo(width);
		height = findPrizerulo(height);

		let extras = driving;

		switch (modelCode) {
			case 0:
				totalPrice = rollerStandart[height][width];
				totalPrice *= Coeficientrulo[0][colorCode];
				if (extras == 1) {
					totalPrice += 5.9;
				} break;

			case 1:
				totalPrice = rollerElegans[height][width];
				totalPrice *= Coeficientrulo[1][colorCode];
				break;

			case 2:
				totalPrice = rollerPrestige[(height - 2)][width];
				totalPrice *= Coeficientrulo[2][colorCode];
				if (extras == 1) {
					totalPrice += 12.9;
				}break;
		}

		totalPrice -= totalPrice * (discount / 100);

		return totalPrice;
	}
}

export default {
    calculate,
}
