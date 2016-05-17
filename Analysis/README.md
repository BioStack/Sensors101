# Analysis

The following contains a walkthrough for doing basic data analysis of several of the sensors.

### Prereqs

If doing on your own machine, you'll need to install [R](https://www.r-project.org/) and have a c/c++ dependecies such as clang/gcc/make.

Then, get files for this workshop.

```
git clone https://github.com/BioStack/Sensors101
cd Sensors101/Analysis
```

Finally, install dependencies (or using RStudio).

```
Rscript install.R
```

### EDA

The template code already reads the signal file from a command line argument or uses a default file. Let's add code to plot it.

```
# Draw original signal
plot(edaSignal, col="green")
```

