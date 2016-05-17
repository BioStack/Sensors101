# Append local library
.libPaths( c( .libPaths(), "./lib") )
library(signal)
library(pracma)
library(wmtsa)

cd("C:/SEmotion/Sensors101/Data");

dataFile <- "../Data/HeartActivity_20160513_133610.csv"

if( length(args) == 2 )
{
	dataFile <- args[1]
}
f.results <- read.table(dataFile, header=TRUE, sep=",")

# Get signal
time = f.results$SensorDateTime
x = time - time[1] # subtract the initial time to start at zer0
y = f.results$HeartRate
max_y = max(y)


# Draw original signal
plot(x, y, type="l", ylim=range(0, 1.5*max_y,5), lwd = 1, col = "green")

