﻿function calculate(model, color, width, height, driving = false, planks = false) {

    //Gettign values from sizes form for Horizontals and Verticals and Prints the result
    var colorCode = 0;	//default color
    var modelCode = 0; // default model
    var totalPrice = 0;
    //var selectedVerticalType;


    //Horizontals MODELS ---------------------------
    var horizontalModels = ["пред стъкло", "пред стъкло bo", "между стъкло", "макси стандарт", "макси bo", "макси лукс", "ultimate", "megaview", "varioflex"];

    //Horizontal COLORS
    var horizontalColors = [
        "18", 	                                                       // price group 0 - to 0
        "7", "27", "58", "62", "63", "144", "302", "315", "24", "570", "378", "698", "700", "705", "707", "711", "712", "713", "714", "715", "872", "866", "716", "717", "266", "279", "1037", "103", "718", "870", "814", // price group 1 - to 31
        "1000", "027", "738", "695", "441", "43", "241", "330", "1pr", "285pr", "58pr", // price 2 - 42
        "780", "781", "8204", "8300", "754", "755",                               // price group 3 - to 48
        "991", "992", "993", "994", "995", "996", "997", "998",                       // price group 4 - to 56
        "101", "102", "121", "107", "311", "371",                                 // price group 5 - to 62
        "0150", "4459", "7010", "7113",                                     // price group 6 - to 66
        "7327", "7332", "7333", "7346", "7418", "8595",                           // price group 7 - to 72
        "0150p", "4459p", "7010p"                                     // price group 8 - to 75
    ];

    var CoeficientHorizontal = [
        [1.00, 1.07, 1.35, 1.60, 1.80, 1.30, 1.60, 2.50, 2.50],	// Pred Styklo
        [1.10, 1.20, 1.45, 1.70, 1.90, 1.40, 1.70, 2.60, 2.60],	// BlackOut
        [1.00, 1.07, 1.35, 1.60, 1.80, 1.30, 1.60, 2.50, 2.50],	// Mejdu Styklo
        [1.00, 1.10, 1.25, 1.50, 1.60, 1.20, 1.50, 2.20, 2.20],	// Maxi Standart
        [1.10, 1.20, 1.35, 1.60, 1.70, 1.30, 1.60, 2.30, 2.30],	// Maxi BlackOut
        [1.40, 1.45, 1.50, 1.70, 1.75, 1.45, 1.70, 2.40, 2.40], // Maxi Lux
        [0.00, 0.00, 0.00, 0.00, 1.25, 1.00, 1.20, 1.60, 1.60],	// UltiMate
        [0.00, 0.00, 0.00, 0.00, 1.40, 1.15, 1.35, 1.75, 1.75], // MegaView
        [0.00, 0.00, 0.00, 0.00, 1.90, 1.65, 1.85, 2.25, 2.25]  // VarioFlex
    ];

    var predStykloTable = [
        [16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 17, 17, 20, 20, 21, 22, 22, 24, 26, 26, 27, 28, 28, 29, 29, 31, 32, 34],
        [16, 16, 16, 16, 16, 16, 16, 16, 17, 18, 20, 20, 22, 24, 24, 26, 27, 28, 29, 29, 31, 32, 34, 34, 35, 37, 38, 39],
        [16, 16, 16, 16, 16, 16, 17, 18, 20, 21, 22, 24, 26, 27, 28, 29, 31, 32, 34, 34, 35, 37, 38, 39, 40, 43, 44, 46],
        [16, 16, 16, 16, 16, 17, 18, 20, 21, 22, 24, 27, 28, 29, 31, 32, 34, 37, 38, 39, 40, 43, 44, 45, 46, 48, 49, 52],
        [16, 16, 16, 16, 17, 18, 21, 22, 24, 26, 27, 29, 31, 34, 35, 37, 38, 39, 43, 44, 45, 46, 48, 49, 52, 54, 55, 57],
        [16, 16, 16, 16, 18, 21, 22, 24, 26, 28, 29, 32, 35, 37, 38, 40, 43, 44, 46, 48, 49, 52, 54, 55, 56, 59, 60, 63],
        [16, 16, 16, 17, 20, 22, 24, 27, 28, 29, 32, 35, 38, 39, 43, 44, 46, 48, 50, 52, 54, 56, 57, 60, 62, 65, 66, 71],
        [16, 16, 16, 18, 21, 24, 26, 28, 31, 32, 35, 38, 40, 44, 45, 48, 49, 52, 55, 56, 59, 60, 63, 66, 67, 71, 72, 76],
        [16, 16, 17, 20, 22, 26, 28, 31, 32, 35, 38, 40, 44, 46, 49, 50, 54, 56, 59, 60, 63, 66, 67, 71, 73, 76, 77, 82],
        [16, 16, 18, 21, 24, 27, 29, 32, 35, 38, 40, 44, 46, 49, 52, 55, 57, 60, 63, 65, 67, 71, 73, 76, 78, 82, 83, 87],
        [16, 17, 20, 22, 26, 28, 31, 34, 37, 39, 44, 46, 49, 52, 55, 59, 62, 65, 67, 71, 73, 76, 78, 82, 84, 87, 90, 94],
        [16, 17, 20, 24, 27, 31, 34, 37, 39, 43, 45, 49, 54, 56, 59, 62, 65, 67, 72, 74, 77, 80, 83, 85, 88, 91, 95, 100],
        [16, 18, 21, 24, 28, 32, 35, 38, 43, 45, 48, 52, 56, 59, 62, 66, 68, 72, 74, 78, 82, 84, 88, 91, 94, 96, 101, 105],
        [16, 18, 22, 26, 29, 34, 37, 40, 44, 48, 50, 55, 59, 62, 66, 68, 73, 76, 78, 83, 85, 90, 93, 96, 100, 102, 106, 111],
        [17, 20, 24, 27, 31, 35, 39, 43, 46, 49, 54, 57, 62, 66, 68, 73, 76, 80, 83, 87, 91, 94, 99, 101, 105, 108, 112, 118],
        [17, 21, 24, 28, 32, 37, 40, 45, 48, 52, 56, 60, 65, 68, 73, 76, 80, 84, 87, 91, 95, 100, 102, 106, 111, 113, 118, 123],
        [18, 21, 26, 29, 34, 38, 43, 46, 50, 55, 59, 63, 68, 72, 76, 80, 84, 88, 91, 95, 100, 104, 108, 112, 115, 119, 123, 129],
        [18, 22, 27, 31, 35, 40, 45, 49, 54, 56, 62, 66, 72, 76, 80, 84, 88, 91, 95, 100, 104, 108, 112, 116, 121, 124, 129, 134],
        [18, 24, 28, 32, 37, 43, 46, 50, 55, 59, 65, 68, 74, 78, 83, 87, 91, 95, 100, 105, 110, 113, 118, 122, 127, 130, 134, 141],
        [20, 24, 28, 34, 38, 44, 48, 52, 57, 62, 66, 72, 77, 82, 87, 91, 95, 100, 104, 110, 113, 118, 122, 128, 132, 136, 0, 0],
        [20, 26, 29, 34, 39, 45, 50, 55, 59, 65, 68, 74, 80, 85, 90, 94, 100, 104, 108, 113, 118, 123, 128, 132, 138, 0, 0, 0],
        [21, 26, 31, 35, 40, 46, 52, 56, 62, 66, 72, 77, 83, 88, 93, 99, 102, 108, 112, 118, 122, 128, 132, 138, 0, 0, 0, 0],
        [21, 27, 32, 37, 43, 49, 54, 59, 63, 68, 74, 80, 87, 91, 96, 101, 106, 112, 116, 122, 128, 132, 138, 0, 0, 0, 0, 0],
        [22, 28, 32, 38, 44, 50, 56, 60, 66, 72, 77, 83, 90, 95, 100, 105, 111, 116, 121, 127, 132, 138, 0, 0, 0, 0, 0, 0],
        [22, 28, 34, 39, 45, 52, 57, 63, 68, 74, 80, 85, 93, 99, 104, 110, 115, 119, 124, 130, 136, 0, 0, 0, 0, 0, 0, 0],
        [24, 29, 35, 40, 46, 54, 59, 65, 71, 76, 83, 88, 95, 101, 106, 112, 118, 123, 129, 134, 0, 0, 0, 0, 0, 0, 0, 0],
        [24, 29, 37, 43, 48, 55, 60, 67, 73, 78, 85, 91, 99, 104, 111, 116, 122, 128, 133, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        [26, 31, 37, 44, 49, 56, 63, 68, 74, 82, 87, 94, 101, 108, 113, 119, 127, 132, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        [26, 32, 38, 45, 50, 59, 65, 72, 77, 83, 90, 96, 105, 111, 118, 123, 129, 136, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    ];

    var maxiTable = [
        [17, 17, 17, 17, 17, 17, 17, 17, 19, 21, 21, 22, 23, 25, 26, 27, 28, 30, 31, 31, 32, 33, 36, 37, 38, 38, 39, 41],
        [17, 17, 17, 17, 17, 17, 19, 19, 21, 22, 23, 25, 27, 28, 30, 31, 32, 33, 36, 37, 38, 39, 41, 42, 43, 44, 46, 48],
        [17, 17, 17, 17, 17, 19, 21, 22, 23, 25, 27, 28, 30, 31, 32, 36, 37, 38, 39, 41, 42, 43, 44, 48, 49, 50, 52, 54],
        [17, 17, 17, 17, 17, 21, 22, 25, 26, 27, 30, 31, 32, 36, 37, 38, 41, 42, 43, 44, 48, 49, 50, 53, 54, 55, 57, 59],
        [17, 17, 17, 17, 21, 22, 25, 26, 28, 30, 32, 33, 37, 38, 41, 42, 43, 46, 48, 50, 52, 54, 55, 57, 59, 60, 64, 66],
        [17, 17, 17, 19, 22, 25, 26, 28, 30, 32, 36, 37, 39, 42, 43, 46, 48, 50, 53, 54, 57, 58, 60, 63, 65, 68, 69, 71],
        [17, 17, 17, 21, 23, 26, 28, 30, 32, 36, 38, 39, 42, 44, 48, 50, 52, 54, 57, 58, 60, 64, 66, 68, 70, 73, 75, 79],
        [17, 17, 19, 22, 25, 27, 30, 32, 36, 38, 41, 42, 46, 49, 52, 53, 55, 58, 60, 64, 66, 69, 70, 73, 76, 79, 81, 84],
        [17, 17, 21, 23, 26, 28, 31, 33, 37, 39, 43, 46, 49, 52, 54, 57, 59, 63, 65, 68, 70, 73, 76, 79, 81, 84, 86, 91],
        [17, 19, 22, 25, 27, 31, 33, 37, 39, 42, 46, 49, 52, 55, 58, 60, 64, 66, 69, 73, 76, 79, 81, 84, 86, 90, 93, 96],
        [17, 19, 23, 26, 28, 32, 36, 38, 42, 44, 49, 52, 55, 58, 60, 65, 68, 70, 75, 77, 80, 84, 86, 90, 92, 96, 98, 103],
        [17, 21, 23, 27, 30, 33, 38, 41, 43, 48, 52, 54, 58, 63, 65, 68, 71, 75, 79, 81, 85, 87, 92, 95, 98, 102, 104, 109],
        [17, 22, 25, 28, 31, 36, 39, 43, 46, 50, 54, 57, 60, 65, 69, 71, 76, 79, 82, 86, 90, 93, 96, 100, 104, 107, 111, 114],
        [17, 22, 26, 30, 32, 38, 41, 44, 49, 53, 57, 59, 65, 69, 71, 76, 80, 82, 86, 91, 95, 97, 102, 106, 109, 112, 117, 122],
        [19, 23, 27, 31, 33, 39, 43, 48, 52, 54, 59, 63, 68, 71, 76, 80, 84, 87, 91, 95, 98, 103, 107, 111, 114, 119, 123, 127],
        [19, 23, 28, 32, 37, 41, 44, 49, 53, 57, 63, 66, 70, 75, 80, 84, 87, 92, 96, 100, 104, 108, 112, 117, 120, 124, 129, 134],
        [21, 25, 28, 32, 38, 42, 48, 52, 55, 59, 65, 69, 75, 79, 82, 86, 92, 96, 100, 104, 108, 112, 118, 122, 125, 130, 134, 139],
        [21, 26, 30, 33, 39, 44, 49, 53, 58, 63, 68, 71, 77, 81, 86, 91, 95, 100, 104, 108, 113, 118, 122, 127, 131, 135, 140, 146],
        [22, 26, 31, 36, 41, 46, 50, 55, 59, 65, 70, 75, 80, 85, 90, 95, 98, 104, 108, 113, 118, 123, 127, 133, 136, 141, 146, 152],
        [22, 27, 32, 37, 42, 48, 53, 58, 63, 68, 73, 77, 84, 87, 93, 98, 103, 108, 113, 118, 123, 127, 133, 138, 141, 147, 0, 0],
        [23, 28, 33, 38, 43, 50, 54, 59, 65, 70, 76, 80, 86, 92, 97, 102, 107, 112, 118, 122, 127, 133, 138, 144, 147, 0, 0, 0],
        [23, 28, 33, 39, 44, 52, 57, 63, 68, 71, 79, 84, 90, 95, 100, 106, 111, 117, 122, 127, 133, 138, 144, 149, 0, 0, 0, 0],
        [25, 30, 36, 41, 46, 53, 58, 64, 69, 75, 81, 86, 93, 98, 104, 109, 114, 120, 125, 131, 136, 141, 147, 0, 0, 0, 0, 0],
        [26, 31, 37, 42, 48, 54, 60, 66, 71, 77, 84, 90, 96, 102, 108, 113, 119, 124, 130, 136, 141, 147, 0, 0, 0, 0, 0, 0],
        [26, 31, 38, 43, 49, 57, 63, 68, 75, 80, 86, 92, 98, 106, 111, 117, 123, 129, 135, 140, 146, 0, 0, 0, 0, 0, 0, 0],
        [27, 32, 39, 44, 50, 58, 64, 70, 76, 82, 90, 95, 103, 108, 114, 120, 127, 133, 139, 145, 0, 0, 0, 0, 0, 0, 0, 0],
        [27, 33, 39, 46, 53, 59, 66, 71, 79, 85, 92, 97, 106, 112, 118, 124, 131, 136, 144, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        [28, 33, 41, 48, 54, 60, 68, 75, 81, 87, 95, 100, 108, 114, 122, 129, 135, 140, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        [28, 36, 42, 49, 55, 64, 70, 77, 82, 90, 97, 104, 112, 119, 125, 133, 139, 145, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    ];

    var megaViewTable = [

        [30, 30, 30, 31, 33, 39, 42, 43, 46, 49, 52, 54, 60, 63, 65, 68, 69, 71, 75, 77, 79, 81, 84, 85, 87, 91, 93, 100],
        [30, 30, 31, 33, 36, 42, 44, 48, 50, 53, 55, 58, 65, 68, 70, 73, 76, 79, 81, 84, 86, 90, 91, 93, 96, 98, 102, 109],
        [30, 30, 32, 36, 38, 44, 48, 50, 53, 55, 59, 63, 70, 73, 76, 79, 81, 85, 87, 91, 93, 96, 98, 102, 104, 108, 111, 119],
        [30, 31, 33, 38, 41, 48, 50, 54, 57, 59, 64, 68, 75, 79, 81, 84, 87, 91, 95, 97, 100, 104, 107, 109, 113, 117, 119, 129],
        [30, 32, 36, 39, 42, 50, 53, 57, 59, 64, 68, 71, 80, 84, 86, 91, 93, 97, 100, 104, 108, 111, 114, 118, 122, 124, 129, 138],
        [30, 33, 38, 41, 44, 53, 57, 59, 64, 68, 71, 76, 85, 87, 92, 96, 100, 104, 107, 111, 114, 119, 123, 125, 130, 134, 138, 147],
        [31, 36, 39, 43, 48, 55, 59, 64, 68, 71, 76, 80, 90, 93, 97, 102, 106, 109, 113, 118, 122, 125, 130, 134, 138, 141, 146, 157],
        [32, 37, 41, 44, 50, 58, 63, 66, 70, 75, 81, 85, 95, 98, 103, 107, 112, 117, 120, 124, 130, 134, 138, 141, 146, 151, 156, 166],
        [33, 38, 42, 48, 52, 60, 65, 69, 75, 79, 85, 90, 98, 104, 108, 113, 118, 123, 127, 131, 136, 140, 146, 150, 156, 160, 165, 174],
        [36, 39, 44, 49, 54, 64, 68, 73, 77, 82, 90, 93, 104, 109, 113, 119, 124, 129, 134, 139, 144, 149, 154, 158, 163, 168, 173, 184],
        [36, 41, 46, 52, 57, 66, 70, 76, 81, 86, 93, 98, 109, 113, 119, 124, 130, 135, 140, 146, 151, 156, 161, 166, 172, 177, 183, 193],
        [37, 42, 48, 53, 58, 69, 75, 80, 85, 91, 97, 103, 113, 119, 124, 130, 136, 141, 147, 152, 158, 163, 168, 174, 179, 185, 190, 203],
        [38, 43, 49, 55, 60, 70, 77, 82, 87, 93, 102, 107, 119, 124, 130, 136, 141, 147, 154, 160, 165, 172, 177, 183, 188, 194, 200, 212],
        [39, 44, 52, 57, 64, 73, 80, 85, 92, 97, 106, 112, 123, 130, 135, 141, 147, 154, 161, 166, 173, 178, 185, 190, 198, 203, 210, 221],
        [41, 46, 53, 59, 65, 76, 82, 90, 95, 102, 109, 117, 129, 135, 140, 147, 154, 161, 166, 173, 179, 187, 192, 199, 205, 212, 217, 231],
        [41, 48, 54, 60, 68, 79, 85, 92, 98, 106, 113, 120, 134, 140, 146, 152, 160, 166, 173, 179, 187, 193, 200, 206, 214, 220, 227, 241],
        [42, 49, 57, 64, 70, 81, 87, 95, 103, 109, 118, 125, 138, 145, 151, 160, 166, 173, 179, 187, 194, 201, 208, 215, 221, 228, 237, 249],
        [43, 50, 58, 65, 71, 84, 91, 98, 106, 112, 122, 130, 144, 150, 158, 165, 172, 179, 187, 193, 201, 208, 216, 222, 230, 238, 244, 259],
        [44, 52, 59, 68, 75, 86, 95, 102, 109, 117, 127, 134, 147, 156, 163, 171, 178, 185, 193, 201, 208, 216, 222, 231, 239, 246, 254, 269],
        [46, 54, 60, 69, 77, 90, 97, 106, 112, 120, 131, 138, 152, 161, 168, 176, 184, 192, 200, 208, 216, 222, 231, 239, 247, 255, 0, 0],
        [48, 55, 64, 71, 79, 92, 100, 108, 117, 124, 135, 144, 158, 166, 174, 183, 190, 199, 206, 215, 222, 231, 239, 247, 255, 0, 0, 0],
        [48, 57, 65, 73, 81, 95, 103, 111, 119, 129, 139, 147, 162, 171, 179, 188, 195, 204, 214, 221, 230, 238, 247, 255, 0, 0, 0, 0],
        [49, 58, 66, 75, 84, 97, 106, 114, 123, 131, 144, 151, 167, 176, 185, 193, 203, 211, 220, 228, 238, 246, 255, 0, 0, 0, 0, 0],
        [50, 59, 68, 77, 86, 100, 108, 118, 127, 135, 147, 157, 172, 181, 190, 199, 208, 217, 226, 235, 244, 254, 0, 0, 0, 0, 0, 0],
        [52, 60, 70, 79, 87, 103, 112, 120, 130, 139, 151, 161, 177, 187, 195, 205, 215, 222, 232, 242, 252, 0, 0, 0, 0, 0, 0, 0],
        [53, 63, 71, 81, 91, 106, 114, 124, 134, 144, 156, 165, 181, 192, 201, 211, 220, 230, 239, 248, 0, 0, 0, 0, 0, 0, 0, 0],
        [53, 64, 73, 82, 93, 108, 118, 127, 136, 147, 160, 171, 187, 195, 206, 216, 226, 237, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        [54, 65, 75, 85, 95, 111, 120, 131, 140, 151, 163, 174, 192, 201, 212, 221, 232, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        [55, 66, 77, 86, 97, 112, 123, 134, 145, 154, 167, 178, 195, 206, 217, 228, 238, 248, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    ];
    getModel(model);
    getColor(color);
    let error = checkBoundorieshs(modelCode, width, height);
    return printFinalPricehs(error);

    // When clicked on the select menu
    function getColor(color) {
        colorCode = horizontalColors.indexOf(color.toLowerCase());
    }

    function getModel(model) {
        modelCode = horizontalModels.indexOf(model.toLowerCase());	//models are the rows in  horizontalTable
        selctedVerical = model;

        //if (modelCode > 1) {
        //    plankiCheck = document.getElementById("luxPlankiTd");
        //    document.getElementById("luxPlanki").checked = 0;
        //    plankiCheck.style.display = "none";
        //} else {
        //    plankiCheck.style.display = "block";
        //}

    }

    function findPrizeHorizontal(arg) {
        var local = Math.round(Math.ceil(arg) / 10);

        //local = local / 10;

        if (local < 0) {
            local = 0;
        }

        return local;
    }

    // checkes the width and hitght
    function checkBoundorieshs(model, width, height) {
        var errorMSG = "Зададените размери са извън позволената ширина/височина на продукта";
        var isThereError = false;
        switch (model) {
            case 0:
            case 2:
                {
                    if (width < 20 || width > 380 || height < 10 || height > 350) {
                        isThereError = true;
                    }
                } break;

            case 1:
                if (width < 26 || width > 380 || height < 10 || height > 350) {
                    isThereError = true;
                } break;

            case 3:
                if (width < 22 || width > 300 || height < 10 || height > 350) {
                    isThereError = true;
                } break;

            case 4:
                if (width < 26 || width > 300 || height < 10 || height > 350) {
                    isThereError = true;
                } break;

            case 5:
                if (width < 19 || width > 300 || height < 10 || height > 220) {
                    isThereError = true;
                } break;

            case 6:
                if (width < 32 || width > 330 || height < 20 || height > 300) {
                    isThereError = true;
                } break;

            case 7:
                if (width < 32 || width > 270 || height < 20 || height > 300) {
                    isThereError = true;
                } break;

            case 8:
                if (width < 41 || width > 300 || height < 40 || height > 300) {
                    isThereError = true;
                } break;
        }
        if (isThereError) {
            return errorMSG;

        }
        else {
            undefined;
        }
    }

    function printFinalPricehs(error) {
        if (error !== undefined) {
            return error
        }
        var sizeWidthRaw = width;
        var sizeHeightRaw = height;

        let sizeWidth = findPrizeHorizontal(sizeWidthRaw);
        let sizeHeight = findPrizeHorizontal(sizeHeightRaw);
        sizeWidth -= 3;
        sizeHeight -= 2;

        if (sizeWidth < 0) {
            sizeWidth = 0
        }

        if (sizeHeight < 0) {
            sizeHeight = 0
        }

        var squareMeters;
        var pricePerSquareMeter = 0;
        var discount = 6;	//precent discount
        var colorGroup;
        var errorMSG = "Зададените размери са извън позволената площ на продукта";

        var normalMaxSquareMeters = 6;
        var ultimateMegaMaxSqareMeters = 4;

        //finding The colors
        if (colorCode == 0) {
            colorGroup = 0;
        }
        if (colorCode > 0) {
            colorGroup = 1;
        }
        if (colorCode > 31) {	// old 40
            colorGroup = 2;
        }
        if (colorCode > 42) {
            colorGroup = 3;
        }
        if (colorCode > 48) {
            colorGroup = 4;
        }
        if (colorCode > 56) {
            colorGroup = 5;
        }
        if (colorCode > 62) {
            colorGroup = 6;
        }
        if (colorCode > 66) {
            colorGroup = 7;
        }
        if (colorCode > 72) {
            colorGroup = 8;
        }
        if (colorCode > 77) {
            colorGroup = 9;
        }

        switch (modelCode) {
            case 0:
                totalPrice = predStykloTable[sizeHeight][sizeWidth];
                totalPrice *= CoeficientHorizontal[0][colorGroup];
                break;
            case 1:
                totalPrice = predStykloTable[sizeHeight][sizeWidth];
                totalPrice *= CoeficientHorizontal[1][colorGroup];
                break;
            case 2:
                totalPrice = predStykloTable[sizeHeight][sizeWidth];
                totalPrice *= CoeficientHorizontal[2][colorGroup];
                break;
            case 3:
                totalPrice = maxiTable[sizeHeight][sizeWidth];
                totalPrice *= CoeficientHorizontal[3][colorGroup];
                break;
            case 4:
                totalPrice = maxiTable[sizeHeight][sizeWidth];
                totalPrice *= CoeficientHorizontal[4][colorGroup];
                break;
            case 5:
                totalPrice = maxiTable[sizeHeight][sizeWidth];
                totalPrice *= CoeficientHorizontal[5][colorGroup];
                break;
            case 6:
                totalPrice = megaViewTable[sizeHeight][sizeWidth];
                totalPrice *= CoeficientHorizontal[6][colorGroup];
                break;
            case 7:
                totalPrice = megaViewTable[sizeHeight][sizeWidth];
                totalPrice *= CoeficientHorizontal[7][colorGroup];
                break;
            case 8:
                totalPrice = megaViewTable[sizeHeight][sizeWidth];
                totalPrice *= CoeficientHorizontal[8][colorGroup];
                break;
        }

        squareMeters = sizeWidth * sizeHeight / 10000;
        // checking the boundories
        if (squareMeters > normalMaxSquareMeters) {
            return errorMSG;
        }

        if (modelCode == 4 || modelCode == 8) 	// Po princip e 5 ; ) blabla
        {
            if (squareMeters > 2) {
                return errorMSG;
            }
        }
        if (modelCode == 7) {
            if (squareMeters > ultimateMegaMaxSqareMeters) {
                return errorMSG;
            }
        }

        checkBoundorieshs(modelCode, sizeWidthRaw, sizeHeightRaw);

        var StrVodeneChk = driving;
        var PlankiLux = planks;

        if (StrVodeneChk == 1 && totalPrice > 0) {

            if (modelCode >= 6) {
                totalPrice = totalPrice + 5.5;
            }
            else {
                totalPrice = totalPrice + 4.9;
            }
        }
        if (PlankiLux == 1 && totalPrice > 0) {
            totalPrice = totalPrice + 0.5;
        }

        totalPrice -= totalPrice * (discount / 100);

        if (totalPrice == 0) {
            return totalPrice = "Неподдържан цвят за този модел";

        }
        else {

            return totalPrice
        }
    }
}

export default {
    calculate,
}